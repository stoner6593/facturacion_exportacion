﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using WinApp.Comun;
using WinApp.Comun.Constantes;
using WinApp.Estructuras.CommonAggregateComponents;
using WinApp.Estructuras.CommonExtensionComponents;

namespace WinApp.Estructuras.EstandarUbl
{
    public class DebitNote : IXmlSerializable, IEstructuraXml
    {
        public UblExtensions UblExtensions { get; set; }

        public string UblVersionId { get; set; }

        public string CustomizationId { get; set; }

        public string Id { get; set; }

        public DateTime IssueDate { get; set; }

        public string DocumentCurrencyCode { get; set; }

        public List<DiscrepancyResponse> DiscrepancyResponses { get; set; }

        public List<BillingReference> BillingReferences { get; set; }

        public List<InvoiceDocumentReference> DespatchDocumentReferences { get; set; }

        public List<InvoiceDocumentReference> AdditionalDocumentReferences { get; set; }

        public SignatureCac Signature { get; set; }

        public AccountingSupplierParty AccountingSupplierParty { get; set; }

        public AccountingSupplierParty AccountingCustomerParty { get; set; }

        public List<TaxTotal> TaxTotals { get; set; }

        public LegalMonetaryTotal RequestedMonetaryTotal { get; set; }

        public List<InvoiceLine> DebitNoteLines { get; set; }

        public IFormatProvider Formato { get; set; }
        public InvoiceTypeCode InvoiceTypeCode2 { get; set; }
        public DocumentCurrencyCode DocumentCurrencyCode2 { get; set; }
        public PartyIdentification2 PartyIdentification2 { get; set; }

        public DebitNote()
        {
            UblExtensions = new UblExtensions();
            DiscrepancyResponses = new List<DiscrepancyResponse>();
            BillingReferences = new List<BillingReference>();
            DespatchDocumentReferences = new List<InvoiceDocumentReference>();
            AdditionalDocumentReferences = new List<InvoiceDocumentReference>();
            Signature = new SignatureCac();
            AccountingCustomerParty = new AccountingSupplierParty();
            AccountingSupplierParty = new AccountingSupplierParty();
            TaxTotals = new List<TaxTotal>();
            RequestedMonetaryTotal = new LegalMonetaryTotal();
            DebitNoteLines = new List<InvoiceLine>();
            UblVersionId = "2.1";
            CustomizationId = "2.0";
            Formato = new System.Globalization.CultureInfo(Formatos.Cultura);
            Formato = new System.Globalization.CultureInfo(Formatos.Cultura);
            InvoiceTypeCode2 = new Comun.Constantes.InvoiceTypeCode();
            DocumentCurrencyCode2 = new Comun.Constantes.DocumentCurrencyCode();
            PartyIdentification2 = new PartyIdentification2();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsDebitNote);
            writer.WriteAttributeString("xmlns:cac", EspacioNombres.cac);
            writer.WriteAttributeString("xmlns:cbc", EspacioNombres.cbc);
            writer.WriteAttributeString("xmlns:ccts", EspacioNombres.ccts);
            writer.WriteAttributeString("xmlns:ds", EspacioNombres.ds);
            writer.WriteAttributeString("xmlns:ext", EspacioNombres.ext);
            writer.WriteAttributeString("xmlns:qdt", EspacioNombres.qdt);
            writer.WriteAttributeString("xmlns:sac", EspacioNombres.sac);
            writer.WriteAttributeString("xmlns:udt", EspacioNombres.udt);
            writer.WriteAttributeString("xmlns:xsi", EspacioNombres.xsi);
            var ext2 = UblExtensions.Extension2.ExtensionContent.AdditionalInformation;
            #region UBLExtensions

            {
                writer.WriteStartElement("ext:UBLExtensions");

                #region UBLExtension

                {
                   
                  
                }

                #endregion UBLExtension

                #region UBLExtension

                {
                    writer.WriteStartElement("ext:UBLExtension");

                    #region ExtensionContent

                    {
                        writer.WriteStartElement("ext:ExtensionContent");

                        // En esta zona va el certificado digital.

                        writer.WriteEndElement();
                    }

                    #endregion ExtensionContent

                    writer.WriteEndElement();
                }

                #endregion UBLExtension

                writer.WriteEndElement();
            }

            #endregion UBLExtensions

            writer.WriteElementString("cbc:UBLVersionID", UblVersionId);
            writer.WriteElementString("cbc:CustomizationID", CustomizationId);
            writer.WriteElementString("cbc:ID", Id);
            writer.WriteElementString("cbc:IssueDate", IssueDate.ToString("yyyy-MM-dd"));
            writer.WriteElementString("cbc:IssueTime", String.Format("{0:HH:mm:ss}", DateTime.Now));
            writer.WriteStartElement("cbc:Note");
            writer.WriteAttributeString("languageLocaleID", "1000"); //1000 Monto en letras              
            writer.WriteValue(ext2.AdditionalProperties[0].Value);
            writer.WriteEndElement();
            writer.WriteElementString("cbc:DocumentCurrencyCode", DocumentCurrencyCode);

            #region DiscrepancyResponse

            foreach (var discrepancy in DiscrepancyResponses)
            {
                writer.WriteStartElement("cac:DiscrepancyResponse");
                {
                    writer.WriteElementString("cbc:ReferenceID", discrepancy.ReferenceId);
                    writer.WriteElementString("cbc:ResponseCode", discrepancy.ResponseCode);
                    writer.WriteElementString("cbc:Description", discrepancy.Description);
                }
                writer.WriteEndElement();
            }

            #endregion DiscrepancyResponse

            #region BillingReference

            foreach (var item in BillingReferences)
            {
                writer.WriteStartElement("cac:BillingReference");
                {
                    writer.WriteStartElement("cac:InvoiceDocumentReference");
                    {
                        writer.WriteElementString("cbc:ID", item.InvoiceDocumentReference.Id);
                        writer.WriteElementString("cbc:DocumentTypeCode", item.InvoiceDocumentReference.DocumentTypeCode);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            #endregion BillingReference

            #region DespatchDocumentReference

            foreach (var item in DespatchDocumentReferences)
            {
                writer.WriteStartElement("cac:DespatchDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", item.Id);
                    writer.WriteElementString("cbc:DocumentTypeCode", item.DocumentTypeCode);
                }
                writer.WriteEndElement();
            }

            #endregion DespatchDocumentReference

            #region AdditionalDocumentReference

            foreach (var item in AdditionalDocumentReferences)
            {
                writer.WriteStartElement("cac:AdditionalDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", item.Id);
                    writer.WriteElementString("cbc:DocumentTypeCode", item.DocumentTypeCode);
                }
                writer.WriteEndElement();
            }

            #endregion AdditionalDocumentReference

            #region Signature

            writer.WriteStartElement("cac:Signature");
            writer.WriteElementString("cbc:ID", Signature.Id);

            #region SignatoryParty

            writer.WriteStartElement("cac:SignatoryParty");

            writer.WriteStartElement("cac:PartyIdentification");
            writer.WriteElementString("cbc:ID", Signature.SignatoryParty.PartyIdentification.Id.Value);
            writer.WriteEndElement();

            #region PartyName

            writer.WriteStartElement("cac:PartyName");

            //writer.WriteStartElement("cbc:Name");
            //writer.WriteCData(Signature.SignatoryParty.PartyName.Name);
            //writer.WriteEndElement();
            writer.WriteElementString("cbc:Name", Signature.SignatoryParty.PartyName.Name);

            writer.WriteEndElement();

            #endregion PartyName

            writer.WriteEndElement();

            #endregion SignatoryParty

            #region DigitalSignatureAttachment

            writer.WriteStartElement("cac:DigitalSignatureAttachment");

            writer.WriteStartElement("cac:ExternalReference");
            writer.WriteElementString("cbc:URI", Signature.DigitalSignatureAttachment.ExternalReference.Uri.Trim());
            writer.WriteEndElement();

            writer.WriteEndElement();

            #endregion DigitalSignatureAttachment

            writer.WriteEndElement();

            #endregion Signature

            #region AccountingSupplierParty
            writer.WriteStartElement("cac:AccountingSupplierParty");


            #region Party
            writer.WriteStartElement("cac:Party");

            #region PartyIdentification
            writer.WriteStartElement("cac:PartyIdentification");
            writer.WriteStartElement("cbc:ID");
            writer.WriteAttributeString("schemeID", AccountingSupplierParty.AdditionalAccountId); //Codigo de identificacion de documento de contribuyente
            writer.WriteAttributeString("schemeName", PartyIdentification2.schemeName);
            writer.WriteAttributeString("schemeAgencyName", InvoiceTypeCode2.listAgencyName);
            writer.WriteAttributeString("schemeURI", PartyIdentification2.schemeURI);
            writer.WriteValue(AccountingSupplierParty.CustomerAssignedAccountId);
            writer.WriteEndElement();
            writer.WriteEndElement();
            #endregion PartyIdentification

            #region PartyName
            writer.WriteStartElement("cac:PartyName");

            writer.WriteStartElement("cbc:Name");
            writer.WriteCData(AccountingSupplierParty.Party.PartyLegalEntity.RegistrationName);
            writer.WriteEndElement();

            writer.WriteEndElement();
            #endregion

            #region PostalAddress
            /*writer.WriteStartElement("cac:PostalAddress");
            writer.WriteElementString("cbc:ID", AccountingSupplierParty.Party.PostalAddress.ID);
            writer.WriteElementString("cbc:StreetName", AccountingSupplierParty.Party.PostalAddress.StreetName);
            if (!string.IsNullOrEmpty(AccountingSupplierParty.Party.PostalAddress.CitySubdivisionName))
                writer.WriteElementString("cbc:CitySubdivisionName", AccountingSupplierParty.Party.PostalAddress.CitySubdivisionName);
            writer.WriteElementString("cbc:CityName", AccountingSupplierParty.Party.PostalAddress.CityName);
            writer.WriteElementString("cbc:CountrySubentity", AccountingSupplierParty.Party.PostalAddress.CountrySubentity);
            writer.WriteElementString("cbc:District", AccountingSupplierParty.Party.PostalAddress.District);

            #region Country
            writer.WriteStartElement("cac:Country");
            writer.WriteElementString("cbc:IdentificationCode",
                AccountingSupplierParty.Party.PostalAddress.Country.IdentificationCode);
            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();*/
            #endregion

            #region PartyLegalEntity
            writer.WriteStartElement("cac:PartyLegalEntity");
            writer.WriteStartElement("cbc:RegistrationName");
            writer.WriteCData(AccountingSupplierParty.Party.PartyLegalEntity.RegistrationName);
            writer.WriteEndElement();

            writer.WriteStartElement("cac:RegistrationAddress");
            writer.WriteElementString("cbc:AddressTypeCode", "0000"); //Código del domicilio fiscal sunat
            writer.WriteEndElement();

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region AccountingCustomerParty
            writer.WriteStartElement("cac:AccountingCustomerParty");


            #region Party
            writer.WriteStartElement("cac:Party");

            #region PartyIdentification
            writer.WriteStartElement("cac:PartyIdentification");
            writer.WriteStartElement("cbc:ID");
            writer.WriteAttributeString("schemeID", AccountingCustomerParty.AdditionalAccountId); //Codigo de identificacion de documento de cliente
            writer.WriteAttributeString("schemeName", PartyIdentification2.schemeName);
            writer.WriteAttributeString("schemeAgencyName", InvoiceTypeCode2.listAgencyName);
            writer.WriteAttributeString("schemeURI", PartyIdentification2.schemeURI);
            writer.WriteValue(AccountingCustomerParty.CustomerAssignedAccountId);
            writer.WriteEndElement();
            writer.WriteEndElement();
            #endregion PartyIdentification


            #region cbc:PartyLegalEntity
            writer.WriteStartElement("cac:PartyLegalEntity");

            writer.WriteStartElement("cbc:RegistrationName");
            writer.WriteCData(AccountingCustomerParty.Party.PartyLegalEntity.RegistrationName);
            writer.WriteEndElement();

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion
           
            #region TaxTotal
            foreach (var taxTotal in TaxTotals)
            {
                writer.WriteStartElement("cac:TaxTotal");

                writer.WriteStartElement("cbc:TaxAmount");
                writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
                writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                writer.WriteEndElement();

                #region TaxSubtotal
                {
                    writer.WriteStartElement("cac:TaxSubtotal");

                    writer.WriteStartElement("cbc:TaxableAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxableAmount.CurrencyId);
                    writer.WriteString(taxTotal.TaxableAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    writer.WriteStartElement("cbc:TaxAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
                    writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    #region TaxCategory

                    {
                        writer.WriteStartElement("cac:TaxCategory");

                        #region ID
                        writer.WriteStartElement("cbc:ID");
                        writer.WriteAttributeString("schemeID", "UN/ECE 5305");
                        writer.WriteAttributeString("schemeName", "Tax Category Identifier");
                        writer.WriteAttributeString("schemeAgencyName", "United Nations Economic Commission for Europe");

                        writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.Identifier); 
                        writer.WriteEndElement();
                        #endregion ID

                        #region TaxScheme
                        {
                            writer.WriteStartElement("cac:TaxScheme");

                            writer.WriteStartElement("cbc:ID");
                            writer.WriteAttributeString("schemeID", "UN/ECE 5153");
                            writer.WriteAttributeString("schemeAgencyID", "6");
                            writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id);
                            writer.WriteEndElement();

                            writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
                            writer.WriteElementString("cbc:TaxTypeCode", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);

                            writer.WriteEndElement();
                        }
                        #endregion

                        writer.WriteEndElement();
                    }
                    #endregion

                    writer.WriteEndElement();
                }
                #endregion

                writer.WriteEndElement();
            }
            #endregion


            #region RequestedMonetaryTotal

            writer.WriteStartElement("cac:RequestedMonetaryTotal");

            writer.WriteStartElement("cbc:PayableAmount");
            writer.WriteAttributeString("currencyID", RequestedMonetaryTotal.PayableAmount.CurrencyId);
            writer.WriteValue(RequestedMonetaryTotal.PayableAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
            writer.WriteEndElement();

            writer.WriteEndElement();

            #endregion RequestedMonetaryTotal

            #region DebitNoteLines

            foreach (var line in DebitNoteLines)
            {
                writer.WriteStartElement("cac:DebitNoteLine");

                writer.WriteElementString("cbc:ID", line.Id.ToString());

                #region DebitedQuantity

                writer.WriteStartElement("cbc:DebitedQuantity");
                {
                    //writer.WriteAttributeString("unitCode", line.DebitedQuantity.UnitCode);
                   
                    writer.WriteAttributeString("unitCode", line.DebitedQuantity.UnitCode);
                    writer.WriteAttributeString("unitCodeListID", "UN/ECE rec 20");
                    writer.WriteAttributeString("unitCodeListAgencyName", "United Nations Economic Commission forEurope");
                    writer.WriteValue(line.DebitedQuantity.Value.ToString(Formatos.FormatoNumerico, Formato));
                   

                    //writer.WriteValue(line.DebitedQuantity.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();

                #endregion DebitedQuantity

                #region LineExtensionAmount

                writer.WriteStartElement("cbc:LineExtensionAmount");
                {
                    writer.WriteAttributeString("currencyID", line.LineExtensionAmount.CurrencyId);
                    writer.WriteValue(line.LineExtensionAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();

                #endregion LineExtensionAmount

                #region PricingReference

                writer.WriteStartElement("cac:PricingReference");

                #region AlternativeConditionPrice

                foreach (var item in line.PricingReference.AlternativeConditionPrices)
                {
                    writer.WriteStartElement("cac:AlternativeConditionPrice");

                    #region PriceAmount

                    writer.WriteStartElement("cbc:PriceAmount");
                    writer.WriteAttributeString("currencyID", item.PriceAmount.CurrencyId);
                    writer.WriteValue(item.PriceAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    #endregion PriceAmount

                    //writer.WriteElementString("cbc:PriceTypeCode", item.PriceTypeCode);

                    writer.WriteStartElement("cbc:PriceTypeCode");
                    writer.WriteAttributeString("listName", "Tipo de Precio");
                    writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
                    writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16");
                    writer.WriteValue(item.PriceTypeCode);
                    writer.WriteEndElement();


                    writer.WriteEndElement();
                }

                #endregion AlternativeConditionPrice

                writer.WriteEndElement();

                #endregion PricingReference

                #region AllowanceCharge

                if (line.AllowanceCharge.ChargeIndicator)
                {
                    writer.WriteStartElement("cac:AllowanceCharge");

                    writer.WriteElementString("cbc:ChargeIndicator", line.AllowanceCharge.ChargeIndicator.ToString());

                    #region Amount

                    writer.WriteStartElement("cbc:Amount");
                    writer.WriteAttributeString("currencyID", line.AllowanceCharge.Amount.CurrencyId);
                    writer.WriteValue(line.AllowanceCharge.Amount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    #endregion Amount

                    writer.WriteEndElement();
                }

                #endregion AllowanceCharge

                #region TaxTotal

                {
                    foreach (var taxTotal in line.TaxTotals)
                    {
                        writer.WriteStartElement("cac:TaxTotal");

                        writer.WriteStartElement("cbc:TaxAmount");
                        writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
                        writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                        writer.WriteEndElement();


                        #region TaxSubtotal

                        writer.WriteStartElement("cac:TaxSubtotal");

                        #region TaxableAmount

                        if (!string.IsNullOrEmpty(taxTotal.TaxableAmount.CurrencyId))
                        {
                            writer.WriteStartElement("cbc:TaxableAmount");
                            writer.WriteAttributeString("currencyID", taxTotal.TaxableAmount.CurrencyId);
                            writer.WriteString(taxTotal.TaxableAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                            writer.WriteEndElement();
                        }

                        #endregion TaxableAmount

                        writer.WriteStartElement("cbc:TaxAmount");
                        writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
                        writer.WriteString(taxTotal.TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                        writer.WriteEndElement();
                        if (taxTotal.TaxSubtotal.Percent > 0)
                            writer.WriteElementString("cbc:Percent", taxTotal.TaxSubtotal.Percent.ToString(Formatos.FormatoNumerico, Formato));

                        #region TaxCategory

                        writer.WriteStartElement("cac:TaxCategory");
                        //writer.WriteElementString("cbc:ID", invoiceLine.TaxTotal.TaxSubtotal.TaxCategory.ID);

                        #region ID
                        writer.WriteStartElement("cbc:ID");
                        writer.WriteAttributeString("schemeID", "UN/ECE 5305");
                        writer.WriteAttributeString("schemeName", "Tax Category Identifier");
                        writer.WriteAttributeString("schemeAgencyName", "United Nations Economic Commission for Europe");
                        writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.Identifier); 
                        writer.WriteEndElement();
                        #endregion ID

                        writer.WriteElementString("cbc:Percent", ext2.AdditionalMonetaryTotals[1].Percent.ToString(Formatos.FormatoNumerico, Formato));
                        //writer.WriteElementString("cbc:TaxExemptionReasonCode", taxTotal.TaxSubtotal.TaxCategory.TaxExemptionReasonCode);
                        writer.WriteStartElement("cbc:TaxExemptionReasonCode");
                        writer.WriteAttributeString("listAgencyName", "PE: SUNAT");
                        writer.WriteAttributeString("listName", "Afectacion del IGV");
                        writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07");
                        writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.TaxExemptionReasonCode);
                        writer.WriteEndElement();


                        if (!string.IsNullOrEmpty(taxTotal.TaxSubtotal.TaxCategory.TierRange))
                            writer.WriteElementString("cbc:TierRange", taxTotal.TaxSubtotal.TaxCategory.TierRange);

                        #region TaxScheme

                        {
                            writer.WriteStartElement("cac:TaxScheme");

                            //writer.WriteElementString("cbc:ID", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id);
                            writer.WriteStartElement("cbc:ID");
                            writer.WriteAttributeString("schemeID", "UN/ECE 5153");
                            writer.WriteAttributeString("schemeAgencyID", "6");
                            writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id);
                            writer.WriteEndElement();

                            writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
                            writer.WriteElementString("cbc:TaxTypeCode", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);

                            writer.WriteEndElement();
                        }

                        #endregion TaxScheme

                        writer.WriteEndElement();

                        #endregion TaxCategory

                        writer.WriteEndElement();

                        #endregion TaxSubtotal


                        writer.WriteEndElement();
                    }
                }

                #endregion TaxTotal

                #region Item

                writer.WriteStartElement("cac:Item");

                #region Description

                writer.WriteElementString("cbc:Description", line.Item.Description);
                //writer.WriteStartElement("cbc:Description");
                //writer.WriteCData(invoiceLine.Item.Description);
                //writer.WriteEndElement();

                #endregion Description

                #region SellersItemIdentification

                writer.WriteStartElement("cac:SellersItemIdentification");
                writer.WriteElementString("cbc:ID", line.Item.SellersItemIdentification.Id);
                writer.WriteEndElement();

                #endregion SellersItemIdentification

                #region CommodityClassification
                if (line.ItemClassificationCode != null || line.ItemClassificationCode != "")
                {
                    writer.WriteStartElement("cac:CommodityClassification");
                    writer.WriteStartElement("cbc:ItemClassificationCode");
                    writer.WriteAttributeString("listID", "UNSPSC");
                    writer.WriteAttributeString("listAgencyName", "GS1 US");
                    writer.WriteAttributeString("listName", "Item Classification");
                    writer.WriteValue(line.ItemClassificationCode);//82141601-SERVICIOS FOTOGRAFICOS, MONTAJE Y ENMARCADO	82141602 - MONTAJE DE EXPOSICION DE ARTICULOS
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                #endregion CommodityClassification


                writer.WriteEndElement();

                #endregion Item

                #region Price

                writer.WriteStartElement("cac:Price");

                writer.WriteStartElement("cbc:PriceAmount");
                writer.WriteAttributeString("currencyID", line.Price.PriceAmount.CurrencyId);
                writer.WriteString(line.Price.PriceAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                writer.WriteEndElement();

                writer.WriteEndElement();

                #endregion Price

                writer.WriteEndElement();
            }

            #endregion DebitNoteLines
        }
    }
}
