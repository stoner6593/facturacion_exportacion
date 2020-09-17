using System;
using System.Collections.Generic;
using System.Linq;
using WinApp.Comun;
using WinApp.Comun.Dto.Contratos;
using WinApp.Comun.Dto.Modelos;
using WinApp.Estructuras.CommonAggregateComponents;
using WinApp.Estructuras.CommonBasicComponents;
using WinApp.Estructuras.CommonExtensionComponents;
using WinApp.Estructuras.EstandarUbl;
using WinApp.Estructuras.SunatAggregateComponents;

namespace WinApp.Xml
{
    public class NotaDebitoXml : IDocumentoXml
    {
        IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
        {
            var documento = (DocumentoElectronico)request;
            documento.MontoEnLetras = Conversion.Enletras(documento.TotalVenta);
            var debitNote = new DebitNote
            {
                UblExtensions = new UblExtensions
                {
                    Extension2 = new UblExtension
                    {
                        ExtensionContent = new ExtensionContent
                        {
                            AdditionalInformation = new AdditionalInformation
                            {
                                AdditionalMonetaryTotals = new List<AdditionalMonetaryTotal>()
                                {
                                    new AdditionalMonetaryTotal()
                                    {
                                        Id ="1001",
                                        PayableAmount = new PayableAmount()
                                        {
                                            CurrencyId = documento.Moneda,
                                            Value = documento.Gravadas
                                        }

                                    },
                                    new AdditionalMonetaryTotal {
                                        Percent= (documento.CalculoIgv * 100)
                                    }
                                },

                                AdditionalProperties = new List<AdditionalProperty>()
                                {
                                    new AdditionalProperty
                                    {
                                        Id = "1000",
                                        Value = documento.MontoEnLetras
                                    }
                                }
                            }
                        }
                    }
                },
                Id = documento.IdDocumento,
                IssueDate = DateTime.Parse(documento.FechaEmision),
                DocumentCurrencyCode = documento.Moneda,
                Signature = new SignatureCac
                {
                    Id = documento.IdDocumento,
                    SignatoryParty = new SignatoryParty
                    {
                        PartyIdentification = new PartyIdentification
                        {
                            Id = new PartyIdentificationId
                            {
                                Value = documento.Emisor.NroDocumento
                            }
                        },
                        PartyName = new PartyName
                        {
                            Name = documento.Emisor.NombreLegal
                        }
                    },
                    DigitalSignatureAttachment = new DigitalSignatureAttachment
                    {
                        ExternalReference = new ExternalReference
                        {
                            Uri = $"{documento.Emisor.NroDocumento}-{documento.IdDocumento}"
                        }
                    }
                },
                AccountingSupplierParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountId = documento.Emisor.NroDocumento,
                    AdditionalAccountId = documento.Emisor.TipoDocumento,
                    Party = new Party
                    {
                        PartyName = new PartyName
                        {
                            Name = documento.Emisor.NombreComercial
                        },
                        PostalAddress = new PostalAddress
                        {
                            Id = documento.Emisor.Ubigeo,
                            StreetName = documento.Emisor.Direccion,
                            CitySubdivisionName = documento.Emisor.Urbanizacion,
                            CountrySubentity = documento.Emisor.Departamento,
                            CityName = documento.Emisor.Provincia,
                            District = documento.Emisor.Distrito,
                            Country = new Country { IdentificationCode = "PE" }
                        },
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationName = documento.Emisor.NombreLegal
                        }
                    }
                },
                AccountingCustomerParty = new AccountingSupplierParty
                {
                    CustomerAssignedAccountId = documento.Receptor.NroDocumento,
                    AdditionalAccountId = documento.Receptor.TipoDocumento,
                    Party = new Party
                    {
                        PartyName = new PartyName
                        {
                            Name = documento.Receptor.NombreComercial
                        },
                        PostalAddress = new PostalAddress
                        {
                            Id = documento.Receptor.Ubigeo,
                            StreetName = documento.Receptor.Direccion,
                            CitySubdivisionName = documento.Receptor.Urbanizacion,
                            CountrySubentity = documento.Receptor.Departamento,
                            CityName = documento.Receptor.Provincia,
                            District = documento.Receptor.Distrito,
                            Country = new Country { IdentificationCode = "PE" }
                        },
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationName = documento.Receptor.NombreLegal
                        }
                    }
                },
                UblVersionId = "2.1",
                CustomizationId = "2.0",
                RequestedMonetaryTotal = new LegalMonetaryTotal
                {
                    PayableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.Items.Where(d => d.TipoImpuesto.Contains("21")).Any() ? (documento.TotalVenta + documento.Gratuitas) : documento.TotalVenta//Verifica si un item tiene el tipo de impuesto 21, válido para la NC con productos gratuitos
                    },
                    AllowanceTotalAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.DescuentoGlobal
                    }
                },
                TaxTotals = new List<TaxTotal>()
            };

            /*GRAVADAS*/
            if (documento.Gravadas > 0)
            {
                debitNote.TaxTotals.Add(new TaxTotal
                {
                    //Agregado para la nueva version
                    TaxableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.DescuentoGlobal > 0 ? (documento.Gravadas - documento.DescuentoGlobal) : documento.Gravadas
                    },
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.DescuentoGlobal > 0 ? ((documento.Gravadas - documento.DescuentoGlobal) * documento.CalculoIgv) : documento.TotalIgv
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.DescuentoGlobal > 0 ? ((documento.Gravadas - documento.DescuentoGlobal) * documento.CalculoIgv) : documento.TotalIgv,
                        },
                        TaxCategory = new TaxCategory
                        {
                            Identifier = "S", //VALOR OBTENIDO DE LA TABLA 5
                            TaxScheme = new TaxScheme
                            {
                                Id = "1000",
                                Name = "IGV",
                                TaxTypeCode = "VAT"
                            }
                        }
                    },
                    BaseAmount = new PayableAmount
                    {
                        Value = documento.Gravadas
                    },
                    LineExtensionAmount = new PayableAmount
                    {

                        Value = documento.Gravadas
                    }
                });
            }

            /*EXONERADAS*/
            if (documento.Exoneradas > 0)
            {
                debitNote.TaxTotals.Add(new TaxTotal
                {

                    TaxableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.Exoneradas
                    },
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.TotalIgv
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalIgv,
                        },
                        TaxCategory = new TaxCategory
                        {
                            Identifier = "E",
                            TaxScheme = new TaxScheme
                            {
                                Id = "9997",
                                Name = "EXO",
                                TaxTypeCode = "VAT"
                            }
                        }
                    },
                    LineExtensionAmount = new PayableAmount
                    {

                        Value = documento.Exoneradas
                    }
                });
            }
            /*INAFECTAS*/
            if (documento.Inafectas > 0)
            {

                if (documento.TipoOperacion == "0200")
                {//EXPORTACION

                    debitNote.TaxTotals.Add(new TaxTotal
                    {

                        TaxableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.Inafectas
                        },
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalIgv
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = documento.TotalIgv,
                            },
                            TaxCategory = new TaxCategory
                            {
                                Identifier = "G",
                                TaxScheme = new TaxScheme
                                {
                                    Id = "9995",
                                    Name = "EXP",
                                    TaxTypeCode = "FRE"
                                }
                            }
                        },
                        LineExtensionAmount = new PayableAmount
                        {

                            Value = documento.Inafectas
                        }
                    });
                }
                else
                {
                    debitNote.TaxTotals.Add(new TaxTotal
                    {

                        TaxableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.Inafectas
                        },
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalIgv
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = documento.TotalIgv,
                            },
                            TaxCategory = new TaxCategory
                            {
                                Identifier = "O",
                                TaxScheme = new TaxScheme
                                {
                                    Id = "9998",
                                    Name = "INA",
                                    TaxTypeCode = "FRE"
                                }
                            }
                        }
                    });
                }
            }
            /*GRATUITAS*/
            if (documento.Gratuitas > 0)
            {
                debitNote.TaxTotals.Add(new TaxTotal
                {

                    TaxableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.Gratuitas
                    },
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.TotalIgv
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalIgv,
                        },
                        TaxCategory = new TaxCategory
                        {
                            Identifier = "Z",
                            TaxScheme = new TaxScheme
                            {
                                Id = "9996",
                                Name = "GRA",
                                TaxTypeCode = "FRE"
                            }
                        }
                    },
                    LineExtensionAmount = new PayableAmount
                    {

                        Value = documento.Gratuitas > 0 ? 0 : documento.Gratuitas
                    }
                });


                debitNote.UblExtensions.Extension2.ExtensionContent
                        .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                        {
                            Id = "1002",
                            Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE"
                        });
            }

            foreach (var discrepancia in documento.Discrepancias)
            {
                debitNote.DiscrepancyResponses.Add(new DiscrepancyResponse
                {
                    ReferenceId = discrepancia.NroReferencia,
                    ResponseCode = discrepancia.Tipo,
                    Description = discrepancia.Descripcion
                });
            }

            foreach (var relacionado in documento.Relacionados)
            {
                debitNote.BillingReferences.Add(new BillingReference
                {
                    InvoiceDocumentReference = new InvoiceDocumentReference
                    {
                        Id = relacionado.NroDocumento,
                        DocumentTypeCode = relacionado.TipoDocumento
                    }
                });
            }

            foreach (var relacionado in documento.OtrosDocumentosRelacionados)
            {
                debitNote.AdditionalDocumentReferences.Add(new InvoiceDocumentReference
                {
                    DocumentTypeCode = relacionado.TipoDocumento,
                    Id = relacionado.NroDocumento
                });
            }

            foreach (var detalleDocumento in documento.Items)
            {
                var linea = new InvoiceLine
                {
                    Id = detalleDocumento.Id,
                    ItemClassificationCode=detalleDocumento.ItemClassificationCode,
                    DebitedQuantity = new InvoicedQuantity
                    {
                        UnitCode = detalleDocumento.UnidadMedida,
                        Value = detalleDocumento.Cantidad
                    },
                    LineExtensionAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = detalleDocumento.TotalVenta
                    },
                    PricingReference = new PricingReference
                    {
                        AlternativeConditionPrices = new List<AlternativeConditionPrice>()
                    },
                    Item = new Item
                    {
                        Description = detalleDocumento.Descripcion,
                        SellersItemIdentification = new SellersItemIdentification
                        {
                            Id = detalleDocumento.CodigoItem
                        }
                    },
                    Price = new Price
                    {
                        PriceAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.PrecioUnitario
                        }
                    },
                };
                linea.PricingReference.AlternativeConditionPrices.Add(new AlternativeConditionPrice
                {
                    PriceAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        // Comprobamos que sea una operacion gratuita.
                        Value = documento.Gratuitas > 0 ? 0 : detalleDocumento.PrecioReferencial
                    },
                    PriceTypeCode = detalleDocumento.TipoPrecio
                });
                /* 16 - Afectación al IGV por ítem */
                if (documento.Gravadas > 0)
                {
                    linea.TaxTotals.Add(new TaxTotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.Impuesto
                        },
                        //Agregado para la nueva version
                        TaxableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.TotalVenta
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = detalleDocumento.Impuesto
                            },
                            TaxCategory = new TaxCategory
                            {
                                TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                                Identifier = "S",
                                TaxScheme = new TaxScheme()
                                {
                                    Id = "1000",
                                    Name = "IGV",
                                    TaxTypeCode = "VAT"
                                }
                            }
                        }
                    });
                }

                /* Exoneradas */
                if (documento.Exoneradas > 0)
                {
                    linea.TaxTotals.Add(new TaxTotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.Impuesto
                        },
                        //Agregado para la nueva version
                        TaxableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.TotalVenta
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = detalleDocumento.Impuesto
                            },
                            TaxCategory = new TaxCategory
                            {
                                Identifier = "E",
                                TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                                TaxScheme = new TaxScheme()
                                {
                                    Id = "9997",
                                    Name = "EXO",
                                    TaxTypeCode = "VAT"
                                }
                            }
                        }
                    });
                }

                /*INAFECTAS*/
                if (documento.Inafectas > 0)
                {
                    if (documento.TipoOperacion == "0200")
                    { //EXPORTACION



                        linea.TaxTotals.Add(new TaxTotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = detalleDocumento.Impuesto
                            },
                            //Agregado para la nueva version
                            TaxableAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = detalleDocumento.TotalVenta
                            },
                            TaxSubtotal = new TaxSubtotal
                            {
                                TaxAmount = new PayableAmount
                                {
                                    CurrencyId = documento.Moneda,
                                    Value = detalleDocumento.Impuesto
                                },
                                TaxCategory = new TaxCategory
                                {
                                    Identifier = "G",
                                    TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                                    TaxScheme = new TaxScheme()
                                    {
                                        Id = "9995",
                                        Name = "EXP",
                                        TaxTypeCode = "FRE"
                                    }

                                }
                            }
                        });



                    }
                    else
                    {
                        linea.TaxTotals.Add(new TaxTotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = detalleDocumento.Impuesto
                            },
                            //Agregado para la nueva version
                            TaxableAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = detalleDocumento.TotalVenta
                            },
                            TaxSubtotal = new TaxSubtotal
                            {
                                TaxAmount = new PayableAmount
                                {
                                    CurrencyId = documento.Moneda,
                                    Value = detalleDocumento.Impuesto
                                },
                                TaxCategory = new TaxCategory
                                {
                                    Identifier = "O",
                                    TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                                    TaxScheme = new TaxScheme()
                                    {
                                        Id = "9998",
                                        Name = "INA",
                                        TaxTypeCode = "FRE"
                                    }

                                }
                            }
                        });
                    }
                }

                /*GRATUITAS*/
                if (documento.Gratuitas > 0)
                {
                    linea.TaxTotals.Add(new TaxTotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.Impuesto
                        },
                        //Agregado para la nueva version
                        TaxableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.TotalVenta
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = detalleDocumento.Impuesto
                            },
                            TaxCategory = new TaxCategory
                            {
                                Identifier = "Z",
                                TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                                TaxScheme = new TaxScheme()
                                {
                                    Id = "9996",
                                    Name = "GRA",
                                    TaxTypeCode = "FRE"
                                }

                            }
                        }
                    });
                }


                debitNote.DebitNoteLines.Add(linea);
            }

            return debitNote;
        }
    }
}
