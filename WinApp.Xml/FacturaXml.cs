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
    public class FacturaXml : IDocumentoXml
    {
        IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
        {
            var documento = (DocumentoElectronico)request;
            documento.MontoEnLetras = Conversion.Enletras(documento.TotalVenta);
            var invoice = new Invoice
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
                                        Id = "1001",
                                        PayableAmount = new PayableAmount()
                                        {
                                            CurrencyId = documento.Moneda,
                                            Value = documento.Gravadas
                                        }
                                    },
                                    new AdditionalMonetaryTotal
                                    {
                                        Id = "1002",
                                        PayableAmount = new PayableAmount
                                        {
                                            CurrencyId = documento.Moneda,
                                            Value = documento.Inafectas
                                        }
                                    },
                                    new AdditionalMonetaryTotal
                                    {
                                        Id = "1003",
                                        PayableAmount = new PayableAmount
                                        {
                                            CurrencyId = documento.Moneda,
                                            Value = documento.Exoneradas
                                        }
                                    },
                                    new AdditionalMonetaryTotal
                                    {
                                        Id = "1004",
                                        PayableAmount = new PayableAmount
                                        {
                                            CurrencyId = documento.Moneda,
                                            Value = documento.Gratuitas
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
                                    },
                                    new AdditionalProperty
                                    {
                                        Id = "2006",
                                        Value = "OPERACIÓN SUJETA A DETRACCIÓN"
                                    }
                                }
                            }
                        }
                    }
                },
                Id = documento.IdDocumento,
                IssueDate = DateTime.Parse(documento.FechaEmision),
                IssueTime = documento.IssueTime=="" ? String.Format("{0:HH:mm:ss}", DateTime.Now) : documento.IssueTime,
                InvoiceTypeCode = documento.TipoDocumento,
                DocumentCurrencyCode = documento.Moneda,
                LineCountNumeric = documento.LineCountNumeric,
                Glosa = documento.Glosa,
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
                    CodDomicilioFiscal = documento.Emisor.CodDomicilioFiscal,
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
                            Name = documento.Receptor.NombreComercial ?? string.Empty
                        },
                        PartyLegalEntity = new PartyLegalEntity
                        {
                            RegistrationName = documento.Receptor.NombreLegal
                        }
                    }
                },

                UblVersionId = "2.1",
                CustomizationId = "2.0",
                OrderReference = documento.OrderReference,
                AdditionalItemProperty = documento.AdditionalItemProperty,
                PaymentMeans = new Estructuras.CommonAggregateComponents.PaymentMeans {
                    ID=documento.MediosPago.ID,
                    PaymentMeansCode=documento.MediosPago.PaymentMeansCode
                },
                LegalMonetaryTotal = new LegalMonetaryTotal
                {
                    PayableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value =    documento.TotalVenta //Si existe descuento se recalcular monto gravado
                    },
                    AllowanceTotalAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.DescuentoGlobal,
                        MultiplierFactorNumeric=documento.MultiplierFactorNumeric
                    },
                    BaseAmount = new PayableAmount 
                    /*DESCUENTO GLOBAL - SI EXISTE DESCUENTO RECALCULAMOS SUMATORIA PARA REALIZAR DESCUENTO*/
                    {
                        Value = documento.Items.Where(d => d.TipoImpuesto.StartsWith("1")).Sum(d => d.Suma) +
                                    documento.Items.Where(d => d.TipoImpuesto.Contains("20")).Sum(d => d.Suma) +
                                    documento.Items.Where(d => d.TipoImpuesto.StartsWith("3") || d.TipoImpuesto.Contains("40")).Sum(d => d.Suma) +
                                    documento.Items.Where(d => d.TipoImpuesto.Contains("21")).Sum(d => d.Suma)
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
                TaxTotals = new List<TaxTotal>(),
                DeliveryTerms = new DeliveryTerms {

                    Id= "IMCOTERM",
                    Value=documento.Imcoterm 
                }
               
            };
        
            if (documento.Gravadas > 0)
            {
                invoice.TaxTotals.Add(new TaxTotal
                {
                    //Agregado para la nueva version
                    TaxableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value =  documento.Gravadas
                    },
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.DescuentoGlobal > 0 ? ((documento.Gravadas ) * documento.CalculoIgv) : documento.TotalIgv
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.DescuentoGlobal > 0 ? ((documento.Gravadas) * documento.CalculoIgv) : documento.TotalIgv,
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
                    
                    LineExtensionAmount = new PayableAmount {

                        Value = documento.Gravadas
                    }
                });
            }

            if (documento.Exoneradas > 0)
            {
                invoice.TaxTotals.Add(new TaxTotal
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

            if (documento.Inafectas > 0)
            {

                if (documento.TipoOperacion == "0200")
                {//EXPORTACION

                    invoice.TaxTotals.Add(new TaxTotal
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
                    invoice.TaxTotals.Add(new TaxTotal
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
                        },
                        LineExtensionAmount = new PayableAmount
                        {

                            Value = documento.Inafectas
                        }
                    });
                }
            }


            if (documento.TotalIsc > 0)
            {
                invoice.TaxTotals.Add(new TaxTotal
                {
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.TotalIsc,
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalIsc
                        },
                        TaxCategory = new TaxCategory
                        {
                            Identifier = "S", //VALOR OBTENIDO DE LA TABLA 5
                            TaxScheme = new TaxScheme
                            {
                                Id = "2000",
                                Name = "ISC",
                                TaxTypeCode = "EXC"
                            }
                        }
                    }
                });
            }
            if (documento.TotalOtrosTributos > 0)
            {
                invoice.TaxTotals.Add(new TaxTotal
                {
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.TotalOtrosTributos,
                    },
                    TaxSubtotal = new TaxSubtotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalOtrosTributos
                        },
                        TaxCategory = new TaxCategory
                        {
                            Identifier = "S", //VALOR OBTENIDO DE LA TABLA 5
                            TaxScheme = new TaxScheme
                            {
                                Id = "9999",
                                Name = "OTROS",
                                TaxTypeCode = "OTH"
                            }
                        }
                    }
                });
            }

            /* Numero de Placa del Vehiculo - Gastos art.37° Renta */
            if (!string.IsNullOrEmpty(documento.PlacaVehiculo))
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.SunatCosts.RoadTransport
                    .LicensePlateId = documento.PlacaVehiculo;
            }

            /* Tipo de Operación - Catalogo N° 17 */
            if (!string.IsNullOrEmpty(documento.TipoOperacion)
                && documento.DatosGuiaTransportista == null)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.SunatTransaction.Id = documento.TipoOperacion;
                // Si es Emisor Itinerante.
                if (documento.TipoOperacion == "05")
                {
                    invoice.UblExtensions.Extension2.ExtensionContent
                        .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                        {
                            Id = "3000", // En el catalogo aparece como 2005 pero es 3000
                            Value = "Venta realizada por emisor itinerante"
                        });
                }
            }

            foreach (var relacionado in documento.Relacionados)
            {
                invoice.DespatchDocumentReferences.Add(new InvoiceDocumentReference
                {
                    DocumentTypeCode = relacionado.TipoDocumento,
                    Id = relacionado.NroDocumento
                });
            }

            foreach (var relacionado in documento.OtrosDocumentosRelacionados)
            {
                invoice.AdditionalDocumentReferences.Add(new InvoiceDocumentReference
                {
                    DocumentTypeCode = relacionado.TipoDocumento,
                    Id = relacionado.NroDocumento
                });
            }

            if (documento.Gratuitas > 0 || documento.Items.Where( a => a.TipoImpuesto.ToString() == "21").Any())
            {
                invoice.TaxTotals.Add(new TaxTotal
                {

                    TaxableAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = Convert.ToDecimal(documento.Items.Where(y=>y.TipoImpuesto=="21").Select(a=>a.PrecioReferencial).Sum())
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


                invoice.UblExtensions.Extension2.ExtensionContent
                        .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                        {
                            Id = "1002",
                            Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE"
                        });
            }
            var dctosPorItem = documento.Items.Sum(d => d.Descuento);
            if (documento.DescuentoGlobal > 0 || dctosPorItem > 0)
            {
               
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalMonetaryTotals.Add(new AdditionalMonetaryTotal
                    {
                        Id = "2005",
                        PayableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.DescuentoGlobal + dctosPorItem
                        }
                    });
            }
            if (documento.MontoPercepcion > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalMonetaryTotals.Add(new AdditionalMonetaryTotal
                    {
                        Id = "2001",
                        ReferenceAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalVenta
                        },
                        PayableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.MontoPercepcion
                        },
                        TotalAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.TotalVenta + documento.MontoPercepcion
                        }
                    });
            }
            if (documento.MontoAnticipo > 0)
            {
                invoice.PrepaidPayment = new BillingPayment
                {
                    Id = new PartyIdentificationId
                    {
                        SchemeId = documento.TipoDocAnticipo,
                        Value = documento.DocAnticipo
                    },
                    PaidAmount = new PayableAmount
                    {
                        CurrencyId = documento.MonedaAnticipo,
                        Value = documento.MontoAnticipo
                    },
                    InstructionId = documento.Emisor.NroDocumento
                };
                invoice.LegalMonetaryTotal.PrepaidAmount = new PayableAmount
                {
                    CurrencyId = documento.MonedaAnticipo,
                    Value = documento.MontoAnticipo
                };
            }

            // Datos Adicionales a la Factura.
            foreach (var adicional in documento.DatoAdicionales)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalProperties.Add(new AdditionalProperty
                    {
                        Id = adicional.Codigo,
                        Value = adicional.Contenido
                    });
            }

            if (documento.MontoDetraccion > 0)
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.AdditionalMonetaryTotals.Add(new AdditionalMonetaryTotal
                    {
                        Id = "2003",
                        PayableAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = documento.MontoDetraccion
                        },
                        Percent = documento.CalculoDetraccion * 100
                    });
            }

            // Para datos de Guia de Remision Transportista.
            if (!string.IsNullOrEmpty(documento.DatosGuiaTransportista?.RucTransportista))
            {
                invoice.UblExtensions.Extension2.ExtensionContent
                    .AdditionalInformation.SunatEmbededDespatchAdvice = new SunatEmbededDespatchAdvice
                    {
                        DeliveryAddress = new PostalAddress
                        {
                            Id = documento.DatosGuiaTransportista.DireccionDestino.Ubigeo,
                            StreetName = documento.DatosGuiaTransportista.DireccionDestino.Direccion,
                            CitySubdivisionName = documento.DatosGuiaTransportista.DireccionDestino.Urbanizacion,
                            CityName = documento.DatosGuiaTransportista.DireccionDestino.Departamento,
                            CountrySubentity = documento.DatosGuiaTransportista.DireccionDestino.Provincia,
                            District = documento.DatosGuiaTransportista.DireccionDestino.Distrito,
                            Country = new Country
                            {
                                IdentificationCode = "PE"
                            }
                        },
                        OriginAddress = new PostalAddress
                        {
                            Id = documento.DatosGuiaTransportista.DireccionOrigen.Ubigeo,
                            StreetName = documento.DatosGuiaTransportista.DireccionOrigen.Direccion,
                            CitySubdivisionName = documento.DatosGuiaTransportista.DireccionOrigen.Urbanizacion,
                            CityName = documento.DatosGuiaTransportista.DireccionOrigen.Departamento,
                            CountrySubentity = documento.DatosGuiaTransportista.DireccionOrigen.Provincia,
                            District = documento.DatosGuiaTransportista.DireccionOrigen.Distrito,
                            Country = new Country
                            {
                                IdentificationCode = "PE"
                            }
                        },
                        SunatCarrierParty = new AccountingSupplierParty
                        {
                            CustomerAssignedAccountId = documento.DatosGuiaTransportista.RucTransportista,
                            AdditionalAccountId = "06",
                            Party = new Party
                            {
                                PartyLegalEntity = new PartyLegalEntity
                                {
                                    RegistrationName = documento.DatosGuiaTransportista.NombreTransportista
                                }
                            }
                        },
                        DriverParty = new AgentParty
                        {
                            PartyIdentification = new PartyIdentification
                            {
                                Id = new PartyIdentificationId
                                {
                                    Value = documento.DatosGuiaTransportista.NroLicenciaConducir
                                }
                            }
                        },
                        SunatRoadTransport = new SunatRoadTransport
                        {
                            LicensePlateId = documento.DatosGuiaTransportista.PlacaVehiculo,
                            TransportAuthorizationCode = documento.DatosGuiaTransportista.CodigoAutorizacion,
                            BrandName = documento.DatosGuiaTransportista.MarcaVehiculo
                        },
                        TransportModeCode = documento.DatosGuiaTransportista.ModoTransporte,
                        GrossWeightMeasure = new InvoicedQuantity
                        {
                            UnitCode = documento.DatosGuiaTransportista.UnidadMedida,
                            Value = documento.DatosGuiaTransportista.PesoBruto
                        }
                    };
            }

            foreach (var detalleDocumento in documento.Items)
            {
                var linea = new InvoiceLine
                {
                    Id = detalleDocumento.Id,
                    ItemClassificationCode = detalleDocumento.ItemClassificationCode,
                    InvoicedQuantity = new InvoicedQuantity
                    {
                        UnitCode = detalleDocumento.UnidadMedida,
                        Value = detalleDocumento.Cantidad
                    },
                    LineExtensionAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = documento.Gratuitas > 0 ? 0 : detalleDocumento.TotalVenta
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
                        },
                        AdditionalItemIdentification = new AdditionalItemIdentification
                        {
                            Id = detalleDocumento.PlacaVehiculo
                        }

                    },
                    Price = new Price
                    {
                        PriceAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.PrecioUnitario
                        }
                    }
                    
                    

                };

                /*DETRACCION*/
                var porcentaje = documento.Items.Select(y => y.PorcentajeDetraccion).Max();//  detalleDocumento.PorcentajeDetraccion.Max();
                invoice.PaymentMeans.PaymentTerms.Add(new Estructuras.CommonAggregateComponents.PaymentTerms {
                    PaymentMeansID= detalleDocumento.CodDetraccion,
                    PaymentPercent= porcentaje,
                    Amount= (documento.TotalVenta * (Convert.ToDecimal(porcentaje) /100))

                });
            


                /* 17 - Sistema de ISC por ítem */
                if (detalleDocumento.ImpuestoSelectivo > 0)
                    linea.TaxTotals.Add(new TaxTotal
                    {
                        TaxAmount = new PayableAmount
                        {
                            CurrencyId = documento.Moneda,
                            Value = detalleDocumento.ImpuestoSelectivo
                        },
                        TaxSubtotal = new TaxSubtotal
                        {
                            TaxAmount = new PayableAmount
                            {
                                CurrencyId = documento.Moneda,
                                Value = detalleDocumento.ImpuestoSelectivo
                            },
                            TaxCategory = new TaxCategory
                            {
                                TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                                TierRange = "01",
                                TaxScheme = new TaxScheme()
                                {
                                    Id = "2000",
                                    Name = "ISC",
                                    TaxTypeCode = "EXC"
                                }
                            }
                        }
                    });


                linea.PricingReference.AlternativeConditionPrices.Add(new AlternativeConditionPrice
                {
                    PriceAmount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        // Comprobamos que sea una operacion gratuita.
                        Value = documento.Gratuitas > 0 ? 0 : detalleDocumento.PrecioReferencial
                    },
                    // Para operaciones no onerosas (gratuitas)
                    PriceTypeCode = detalleDocumento.TipoImpuesto.Contains("21") ? "02" : detalleDocumento.TipoPrecio
                });


                // linea.AditionalItemIdentification.Id = documento.PlacaVehiculo;



                /* 51 - Descuentos por ítem */
                if (detalleDocumento.Descuento > 0)
                {
                    linea.AllowanceCharge.ChargeIndicator = false;
                    linea.AllowanceCharge.Amount = new PayableAmount
                    {
                        CurrencyId = documento.Moneda,
                        Value = detalleDocumento.Descuento
                    };
                }


                /* 16 - Afectación al IGV por ítem */
                if (documento.Gravadas > 0  && detalleDocumento.TipoImpuesto.StartsWith("1"))
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
                                Identifier = "S",
                                TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
                                TaxScheme = new TaxScheme()
                                {
                                    Id = "1000",
                                    Name = "IGV",
                                    TaxTypeCode = "VAT"
                                }
                            }
                        }
                    });
                    invoice.InvoiceLines.Add(linea);
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
                    invoice.InvoiceLines.Add(linea);
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
                    else { 
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
                    invoice.InvoiceLines.Add(linea);
                    continue;

                }

                /*GRATUITAS*/
                if (documento.Gratuitas > 0 || detalleDocumento.TipoImpuesto.Contains("21"))
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
                    invoice.InvoiceLines.Add(linea);
                    continue;

                }




       
                
            }

            return invoice;
        }
    }
}
