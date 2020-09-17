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
    public class NotaCreditoXml : IDocumentoXml
    {
        public IEstructuraXml Generar(IDocumentoElectronico request)
        {
            throw new NotImplementedException();
        }

        IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
        {
            var documento = (DocumentoElectronico)request;
            documento.MontoEnLetras = Conversion.Enletras(documento.TotalVenta);
            var creditNote = new CreditNote
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
                LegalMonetaryTotal = new LegalMonetaryTotal
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
                Cargos = new LegalMonetaryTotal
                {

                    AllowanceTotalAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.Cargos,
                        MultiplierFactorNumeric = documento.MultiplierFactorNumeric
                    },

                },
                TaxTotals = new List<TaxTotal>()
            };

            /*GRAVADAS*/
            if (documento.Gravadas > 0)
            {
                creditNote.TaxTotals.Add(new TaxTotal
                {
                    //Agregado para la nueva version
                    TaxableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.Gravadas
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
                creditNote.TaxTotals.Add(new TaxTotal
                {

                    TaxableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.Exoneradas
                    },
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = 0.00m
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = 0.00m,
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

                    creditNote.TaxTotals.Add(new TaxTotal
                    {

                        TaxableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.Inafectas
                        },
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = 0.00m
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = 0.00m,
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
                    creditNote.TaxTotals.Add(new TaxTotal
                    {

                        TaxableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.Inafectas
                        },
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = 0.00m
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = 0.00m,
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
            if (documento.Gratuitas > 0 || documento.Items.Where(a => a.TipoImpuesto.ToString() == "21").Any())
            {
                creditNote.TaxTotals.Add(new TaxTotal
                {

                    TaxableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = Convert.ToDecimal(documento.Items.Where(y => y.TipoImpuesto == "21").Select(a => a.PrecioReferencial).Sum())
                    },
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = 0.00m
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = 0.00m,
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


                creditNote.UblExtensions.Extension2.ExtensionContent
                        .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                        {
                            Id = "1002",
                            Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE"
                        });
            }


            creditNote.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.SunatTransaction.Id = documento.TipoOperacion;

            foreach (var discrepancia in documento.Discrepancias)
            {
                creditNote.DiscrepancyResponses.Add(new DiscrepancyResponse
                {
                    ReferenceId = discrepancia.NroReferencia,
                    ResponseCode = discrepancia.Tipo,
                    Description = discrepancia.Descripcion
                });
            }

            foreach (var relacionado in documento.Relacionados)
            {
                creditNote.BillingReferences.Add(new BillingReference
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
                creditNote.AdditionalDocumentReferences.Add(new InvoiceDocumentReference
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
                    ItemClassificationCode = detalleDocumento.ItemClassificationCode,
                    CreditedQuantity = new InvoicedQuantity
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
                        AlternativeConditionPrices = new List<AlternativeConditionPrice>(),
                        
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
                        Value = /*documento.Gratuitas > 0 ? 0 :*/ detalleDocumento.PrecioReferencial
                    },
                    PriceTypeCode = detalleDocumento.TipoPrecio
                });

                /* 16 - Afectación al IGV por ítem */
                if (documento.Gravadas > 0 && detalleDocumento.TipoImpuesto.StartsWith("1"))
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

                    creditNote.CreditNoteLines.Add(linea);
                    continue;
                }

                /* Exoneradas */
                if (documento.Exoneradas > 0 && detalleDocumento.TipoImpuesto.Contains("20"))
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

                    creditNote.CreditNoteLines.Add(linea);
                    continue;
                }

                /*INAFECTAS*/
                if (documento.Inafectas > 0 && (detalleDocumento.TipoImpuesto.StartsWith("3") || detalleDocumento.TipoImpuesto.Contains("40")))
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

                    creditNote.CreditNoteLines.Add(linea);
                    continue;
                }

                /*GRATUITAS*/
                if (documento.Gratuitas > 0 ||  detalleDocumento.TipoImpuesto.Contains("21"))
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
                            Value = (detalleDocumento.PrecioReferencial * detalleDocumento.Cantidad)
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

                    creditNote.CreditNoteLines.Add(linea);
                    continue;
                }



               
            }

            return creditNote;
        }
    }
}
