using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using WinApp.Comun;
using WinApp.Comun.Constantes;
using WinApp.Estructuras.CommonAggregateComponents;
using WinApp.Estructuras.CommonExtensionComponents;
using WinApp.Estructuras.SunatAggregateComponents;
using System.Linq;

namespace WinApp.Estructuras.EstandarUbl
{
    [Serializable]
    public class Invoice : IXmlSerializable, IEstructuraXml
    {
        public DateTime IssueDate { get; set; }
        public String IssueTime { get; set; }

        public UblExtensions UblExtensions { get; set; }

        public SignatureCac Signature { get; set; }

        public AccountingSupplierParty AccountingSupplierParty { get; set; }

        public string InvoiceTypeCode { get; set; }

        public string Id { get; set; }

        public AccountingSupplierParty AccountingCustomerParty { get; set; }

        public List<InvoiceLine> InvoiceLines { get; set; }

        public List<InvoiceDocumentReference> DespatchDocumentReferences { get; set; }

        public List<InvoiceDocumentReference> AdditionalDocumentReferences { get; set; }

        public string DocumentCurrencyCode { get; set; }

        public List<TaxTotal> TaxTotals { get; set; }

        public LegalMonetaryTotal LegalMonetaryTotal { get; set; }
        public LegalMonetaryTotal Cargos { get; set; }

        public BillingPayment PrepaidPayment { get; set; }

        public string UblVersionId { get; set; }

        public string CustomizationId { get; set; }

        public InvoiceTypeCode InvoiceTypeCode2  { get; set;}
        public DocumentCurrencyCode DocumentCurrencyCode2 { get; set; }
        public PartyIdentification2 PartyIdentification2 { get; set; }
        public IFormatProvider Formato { get; set; }

        public DeliveryTerms DeliveryTerms { get; set; }

        //public List<PaymentTerms> PaymentTerms { get; set; }

        public PaymentMeans PaymentMeans { get; set; }

        public string LineCountNumeric { get; set; }
        public string Glosa { get; set; }
        public decimal LineExtensionAmount { get; set; }
        public string OrderReference { get; set; }
        public string AdditionalItemProperty { get; set; }
        public Invoice()
        {
            AccountingSupplierParty = new AccountingSupplierParty();
            AccountingCustomerParty = new AccountingSupplierParty();
            DespatchDocumentReferences = new List<InvoiceDocumentReference>();
            AdditionalDocumentReferences = new List<InvoiceDocumentReference>();
            UblExtensions = new UblExtensions();
            Signature = new SignatureCac();
            InvoiceLines = new List<InvoiceLine>();
            TaxTotals = new List<TaxTotal>();
            LegalMonetaryTotal = new LegalMonetaryTotal();
            Cargos = new LegalMonetaryTotal();
            UblVersionId = "2.0";
            CustomizationId = "1.0";
            Formato = new System.Globalization.CultureInfo(Formatos.Cultura);
            InvoiceTypeCode2 = new Comun.Constantes.InvoiceTypeCode();
            DocumentCurrencyCode2 = new Comun.Constantes.DocumentCurrencyCode();
            PartyIdentification2 = new PartyIdentification2();
            DeliveryTerms = new DeliveryTerms();
           // PaymentTerms = new List<PaymentTerms>();
            PaymentMeans = new PaymentMeans();
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
            writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsInvoice);
            writer.WriteAttributeString("xmlns:cac", EspacioNombres.cac);
            writer.WriteAttributeString("xmlns:cbc", EspacioNombres.cbc);
            writer.WriteAttributeString("xmlns:ccts", EspacioNombres.ccts);
            writer.WriteAttributeString("xmlns:ds", EspacioNombres.ds);
            writer.WriteAttributeString("xmlns:ext", EspacioNombres.ext);
            writer.WriteAttributeString("xmlns:qdt", EspacioNombres.qdt);
            writer.WriteAttributeString("xmlns:sac", EspacioNombres.sac);
            writer.WriteAttributeString("xmlns:udt", EspacioNombres.udt);
            writer.WriteAttributeString("xmlns:xsi", EspacioNombres.xsi);
            #region UBLExtensions
            writer.WriteStartElement("ext:UBLExtensions");

            #region UBLExtension
            var ext2 = UblExtensions.Extension2.ExtensionContent.AdditionalInformation;

            #endregion

            #region UBLExtension

            writer.WriteStartElement("ext:UBLExtension");
            #region ExtensionContent
            writer.WriteStartElement("ext:ExtensionContent");

            // En esta zona va el certificado digital.

            writer.WriteEndElement();
            #endregion
            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            writer.WriteElementString("cbc:UBLVersionID", UblVersionId);
            writer.WriteElementString("cbc:CustomizationID", CustomizationId);      

            writer.WriteElementString("cbc:ID", Id);
            writer.WriteElementString("cbc:IssueDate", IssueDate.ToString("yyyy-MM-dd"));
            writer.WriteElementString("cbc:IssueTime", IssueTime);
            writer.WriteElementString("cbc:DueDate", IssueDate.ToString("yyyy-MM-dd")); //Fecha de vencimiento de Documento F-B

            writer.WriteStartElement("cbc:InvoiceTypeCode");
            writer.WriteAttributeString("listID", ext2.SunatTransaction.Id); //Tipo de Venta
            writer.WriteAttributeString("listAgencyName",InvoiceTypeCode2.listAgencyName);
            writer.WriteAttributeString("listName", "Tipo de Documento");
            writer.WriteAttributeString("listURI", InvoiceTypeCode2.listURI);
            writer.WriteValue(InvoiceTypeCode); //Tipo de Documento 03 Boleta - 01 Factura
            writer.WriteEndElement();

            writer.WriteStartElement("cbc:Note");
            writer.WriteAttributeString("languageLocaleID", "1000"); //1000 Monto en letras              
            writer.WriteValue(ext2.AdditionalProperties[0].Value);
            writer.WriteEndElement();

            if (ext2.SunatTransaction.Id == "1001") {//Venta sujeta a detracción
                writer.WriteStartElement("cbc:Note");
                writer.WriteAttributeString("languageLocaleID", "2006");               
                writer.WriteValue(ext2.AdditionalProperties[1].Value);
                writer.WriteEndElement();
            }


            #region LEYENDA VENTA GRATUITA
            if (ext2.AdditionalProperties.Count > 1 && ext2.AdditionalProperties[1].Id== "1002") //GLOSA PARA VENTAS GRATUITAS
            {
                writer.WriteStartElement("cbc:Note");
                writer.WriteAttributeString("languageLocaleID", "1002");
                writer.WriteValue(ext2.AdditionalProperties[1].Value);
                writer.WriteEndElement();
            }
            #endregion


            #region GlosaSunat
            if (!string.IsNullOrEmpty(Glosa))
            {
                writer.WriteElementString("cbc:Note", Glosa);
            }
            #endregion

            #region DocumentCurrencyCode

            writer.WriteStartElement("cbc:DocumentCurrencyCode");
            writer.WriteAttributeString("listID", DocumentCurrencyCode2.listID);
            writer.WriteAttributeString("listName", DocumentCurrencyCode2.listName);
            writer.WriteAttributeString("listAgencyName", DocumentCurrencyCode2.listAgencyName);
            writer.WriteValue(DocumentCurrencyCode);
            writer.WriteEndElement();

            #endregion

            writer.WriteElementString("cbc:LineCountNumeric", LineCountNumeric); //Cantidad de Items de la factura

            #region NúmeroOrden
            if (!string.IsNullOrEmpty(OrderReference))
            {
                writer.WriteStartElement("cac:OrderReference");
                writer.WriteStartElement("cbc:ID");
                writer.WriteValue(OrderReference);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            #endregion

            #region DespatchDocumentReferences
            foreach (var reference in DespatchDocumentReferences)
            {
                writer.WriteStartElement("cac:DespatchDocumentReference");
                {
                    writer.WriteElementString("cbc:ID", reference.Id);
                    writer.WriteElementString("cbc:DocumentTypeCode", reference.DocumentTypeCode);
                }
                writer.WriteEndElement();
            }
            #endregion

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

            
            writer.WriteElementString("cbc:Name", Signature.SignatoryParty.PartyName.Name);

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region DigitalSignatureAttachment
            writer.WriteStartElement("cac:DigitalSignatureAttachment");

            writer.WriteStartElement("cac:ExternalReference");
            writer.WriteElementString("cbc:URI", Signature.DigitalSignatureAttachment.ExternalReference.Uri.Trim());
            writer.WriteEndElement();

            writer.WriteEndElement();
            #endregion

            writer.WriteEndElement();
            #endregion

            #region AccountingSupplierParty
            writer.WriteStartElement("cac:AccountingSupplierParty");

          
            #region Party
            writer.WriteStartElement("cac:Party");

            #region PartyIdentification
            writer.WriteStartElement("cac:PartyIdentification");
            writer.WriteStartElement("cbc:ID");
            writer.WriteAttributeString("schemeID", AccountingSupplierParty.AdditionalAccountId); //Codigo de identificacion de documento de contribuyente
            writer.WriteAttributeString("schemeName", "Documento de Identidad");
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
          

            #endregion

            #region PartyLegalEntity
            writer.WriteStartElement("cac:PartyLegalEntity");
            writer.WriteStartElement("cbc:RegistrationName");
            writer.WriteCData(AccountingSupplierParty.Party.PartyLegalEntity.RegistrationName);
            writer.WriteEndElement();

            writer.WriteStartElement("cac:RegistrationAddress");

            writer.WriteStartElement("cbc:AddressTypeCode");           
            writer.WriteAttributeString("listAgencyName", InvoiceTypeCode2.listAgencyName);
            writer.WriteAttributeString("listName", "Establecimientos anexos");
            writer.WriteValue(AccountingSupplierParty.CodDomicilioFiscal);
            writer.WriteEndElement();

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
            writer.WriteAttributeString("schemeName", "Documento de Identidad");
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


            #region PaymentMeans
            if (PaymentMeans != null && ext2.SunatTransaction.Id=="1001") { //Venta sujeta a detracción
                writer.WriteStartElement("cac:PaymentMeans");
                {
                    writer.WriteStartElement("cbc:ID");
                    {
                        
                        writer.WriteValue("Detraccion");
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:PaymentMeansCode");
                    {
                        writer.WriteAttributeString("listID", "UN/CEC 4461");
                        writer.WriteValue(PaymentMeans.PaymentMeansCode);  
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("cac:PayeeFinancialAccount");
                    {
                        writer.WriteStartElement("cbc:ID");
                        {                            
                            writer.WriteValue(PaymentMeans.ID);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            #endregion

            #region PaymentTerms
            foreach(var PaymentTerms in PaymentMeans.PaymentTerms)
            if (PaymentMeans != null && ext2.SunatTransaction.Id == "1001")
            { 
                writer.WriteStartElement("cac:PaymentTerms");
                {
                    writer.WriteStartElement("cbc:ID");
                    {

                        writer.WriteValue("Detraccion");
                    }
                    writer.WriteEndElement();
                        writer.WriteStartElement("cbc:PaymentMeansID");
                    {
                        writer.WriteAttributeString("schemeName", "Codigo de detraccion");
                        writer.WriteAttributeString("schemeAgencyName", InvoiceTypeCode2.listAgencyName);
                        writer.WriteAttributeString("schemeURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo54");
                        writer.WriteValue(PaymentTerms.PaymentMeansID);
                    }
                    writer.WriteEndElement();
                   
                    writer.WriteStartElement("cbc:PaymentPercent");
                    {
                        writer.WriteValue(PaymentTerms.PaymentPercent);
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:Amount");
                    {
                        writer.WriteAttributeString("currencyID", "PEN");//DocumentCurrencyCode
                        writer.WriteValue(PaymentTerms.Amount.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();

                    }
                writer.WriteEndElement();
            }
            #endregion

            #region PrepaidPayment
            if (PrepaidPayment != null)
            {
                writer.WriteStartElement("cac:PrepaidPayment");
                {
                    writer.WriteStartElement("cbc:ID");
                    {
                        writer.WriteAttributeString("schemeID", PrepaidPayment.Id.SchemeId);
                        writer.WriteValue(PrepaidPayment.Id.Value);
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:PaidAmount");
                    {
                        writer.WriteAttributeString("currencyID", PrepaidPayment.PaidAmount.CurrencyId);
                        writer.WriteValue(PrepaidPayment.PaidAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:InstructionID");
                    {
                        writer.WriteAttributeString("schemeID", "6");
                        writer.WriteValue(PrepaidPayment.InstructionId);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            #endregion


            #region AllowanceCharge Cargos/Descuentos
          
                if (LegalMonetaryTotal.AllowanceTotalAmount.Value > 0) //Evalua si hay descuento
                {
                    // < !--En esta sección se ingresara el monto de descuento-->
                    writer.WriteStartElement("cac:AllowanceCharge");
                    writer.WriteElementString("cbc:ChargeIndicator", "false");
                    writer.WriteStartElement("cbc:AllowanceChargeReasonCode");                    
                    writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
                    writer.WriteAttributeString("listName", "Cargo/descuento");
                    writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo53");
                    writer.WriteValue("02");  //Descuentos globales que afectan la base imponible del IGV/IVAP
                    writer.WriteEndElement();

                    //writer.WriteElementString("cbc:MultiplierFactorNumeric", LegalMonetaryTotal.AllowanceTotalAmount.MultiplierFactorNumeric.ToString(Formatos.FormatoNumerico, Formato)); //Habilitar solo si el descuento se hace en % y se debe de consignar en decimales. Ejemplo 5% = 0.05
                    // < !--Monto del descuento-->
                    writer.WriteStartElement("cbc:Amount");
                    writer.WriteAttributeString("currencyID", DocumentCurrencyCode);
                    writer.WriteValue(LegalMonetaryTotal.AllowanceTotalAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();
                    //Monto del cual se hará el descuento
                    writer.WriteStartElement("cbc:BaseAmount");
                    writer.WriteAttributeString("currencyID", DocumentCurrencyCode);
                    writer.WriteValue(LegalMonetaryTotal.BaseAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
                if (Cargos.AllowanceTotalAmount.Value > 0) //Evalua si hay Cargos
                {
                    // < !--En esta sección se ingresara el monto de descuento-->
                    writer.WriteStartElement("cac:AllowanceCharge");
                    writer.WriteElementString("cbc:ChargeIndicator", "true");
                    writer.WriteStartElement("cbc:AllowanceChargeReasonCode");
                    writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
                    writer.WriteAttributeString("listName", "Cargo/descuento");
                    writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo53");
                    writer.WriteValue("50");  //Descuentos globales que afectan la base imponible del IGV/IVAP
                    writer.WriteEndElement();


                    writer.WriteStartElement("cbc:MultiplierFactorNumeric");
                    writer.WriteValue("0");
                    writer.WriteEndElement();

                    writer.WriteStartElement("cbc:Amount");
                    writer.WriteAttributeString("currencyID", DocumentCurrencyCode);
                    writer.WriteValue(Cargos.AllowanceTotalAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();
                   

                    writer.WriteEndElement();
                }
           
            #endregion Descuentos

            #region DeliveryTerms
            if (!string.IsNullOrEmpty(DeliveryTerms.Value)) //Exportacion
            {
                writer.WriteStartElement("cac:DeliveryTerms");
                writer.WriteStartElement("cbc:ID");
                writer.WriteAttributeString("schemeID", "IMCOTERM");          
                writer.WriteValue(DeliveryTerms.Value); 
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            #endregion

            #region TaxTotal

            writer.WriteStartElement("cac:TaxTotal");

            writer.WriteStartElement("cbc:TaxAmount");
            writer.WriteAttributeString("currencyID",TaxTotals[0].TaxAmount.CurrencyId);
            writer.WriteString(TaxTotals[0].TaxAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
            writer.WriteEndElement();

            foreach (var taxTotal in TaxTotals)
            {
                
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

                        writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.Identifier); //VALOR OBTENIDO DE LA TABLA 5
                        writer.WriteEndElement();
                        #endregion ID

                        #region TaxScheme
                        {
                            writer.WriteStartElement("cac:TaxScheme");

                            //writer.WriteElementString("cbc:ID", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.ID);

                            writer.WriteStartElement("cbc:ID");
                            writer.WriteAttributeString("schemeID", "UN/ECE 5305");
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

               
            }
            writer.WriteEndElement();
            #endregion

            #region LegalMonetaryTotal
            writer.WriteStartElement("cac:LegalMonetaryTotal");
            {
                
           
                if (LegalMonetaryTotal.PrepaidAmount.Value > 0) //Monto total de anticipo del comporbante
                {
                    writer.WriteStartElement("cbc:PrepaidAmount");
                    {
                        writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PrepaidAmount.CurrencyId);
                        writer.WriteValue(LegalMonetaryTotal.PrepaidAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }
                if (TaxTotals.Count >0) //Verificar validacion para cuando existen varios tipos de impuesto
                {
                    writer.WriteStartElement("cbc:LineExtensionAmount"); //Valor total de la venta
                    {
                        var a = (from x in TaxTotals select new { todo=x.LineExtensionAmount.Value}).ToList();
                        writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PayableAmount.CurrencyId);
                        writer.WriteValue(TaxTotals.Sum( e => e.LineExtensionAmount.Value).ToString(Formatos.FormatoNumerico, Formato));// [0].LineExtensionAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }
                if (Cargos.AllowanceTotalAmount.Value > 0) //Existe cargos
                {
                    writer.WriteStartElement("cbc:ChargeTotalAmount");
                    {
                        var a = (from x in TaxTotals select new { todo = x.LineExtensionAmount.Value }).ToList();
                        writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PayableAmount.CurrencyId);
                        writer.WriteValue(Cargos.AllowanceTotalAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }

                if (LegalMonetaryTotal.AllowanceTotalAmount.Value > 0 && Cargos.AllowanceTotalAmount.Value ==0)//Descuento
                {
                    writer.WriteStartElement("cbc:AllowanceTotalAmount");
                    {
                        writer.WriteAttributeString("currencyID", LegalMonetaryTotal.AllowanceTotalAmount.CurrencyId);
                        writer.WriteValue(LegalMonetaryTotal.AllowanceTotalAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    }
                    writer.WriteEndElement();
                }
                writer.WriteStartElement("cbc:PayableAmount"); //Total de la venta
                {
                    writer.WriteAttributeString("currencyID", LegalMonetaryTotal.PayableAmount.CurrencyId);
                    writer.WriteValue(LegalMonetaryTotal.PayableAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                }
                writer.WriteEndElement();

           
            }
            writer.WriteEndElement();
            #endregion

            #region InvoiceLines
            foreach (var invoiceLine in InvoiceLines)
            {
                writer.WriteStartElement("cac:InvoiceLine");

                writer.WriteElementString("cbc:ID", invoiceLine.Id.ToString());

                #region InvoicedQuantity
                writer.WriteStartElement("cbc:InvoicedQuantity");
                writer.WriteAttributeString("unitCode", invoiceLine.InvoicedQuantity.UnitCode);
                writer.WriteAttributeString("unitCodeListID", "UN/ECE rec 20");
                writer.WriteAttributeString("unitCodeListAgencyName", "United Nations Economic Commission for Europe");
                writer.WriteValue(invoiceLine.InvoicedQuantity.Value.ToString(Formatos.FormatoNumerico, Formato));
                writer.WriteEndElement();
                #endregion

                #region LineExtensionAmount
                writer.WriteStartElement("cbc:LineExtensionAmount");
                writer.WriteAttributeString("currencyID", invoiceLine.LineExtensionAmount.CurrencyId);
                writer.WriteValue(invoiceLine.LineExtensionAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                writer.WriteEndElement();
                #endregion

                #region PricingReference
                writer.WriteStartElement("cac:PricingReference");

                #region AlternativeConditionPrice
                foreach (var item in invoiceLine.PricingReference.AlternativeConditionPrices)
                {
                    writer.WriteStartElement("cac:AlternativeConditionPrice");

                    #region PriceAmount
                    writer.WriteStartElement("cbc:PriceAmount");
                    writer.WriteAttributeString("currencyID", item.PriceAmount.CurrencyId);
                    writer.WriteValue(item.PriceAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();
                    #endregion

                    // writer.WriteElementString("cbc:PriceTypeCode", item.PriceTypeCode);
                    writer.WriteStartElement("cbc:PriceTypeCode");
                    writer.WriteAttributeString("listName", "Tipo de Precio");
                    writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
                    writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16");
                    writer.WriteValue(item.PriceTypeCode);
                    writer.WriteEndElement();


                    writer.WriteEndElement();
                }
                #endregion

                writer.WriteEndElement();
                #endregion

                #region AllowanceCharge
                if (invoiceLine.AllowanceCharge.ChargeIndicator)
                {
                    writer.WriteStartElement("cac:AllowanceCharge");

                    writer.WriteElementString("cbc:ChargeIndicator", invoiceLine.AllowanceCharge.ChargeIndicator.ToString());

                    #region Amount
                    writer.WriteStartElement("cbc:Amount");
                    writer.WriteAttributeString("currencyID", invoiceLine.AllowanceCharge.Amount.CurrencyId);
                    writer.WriteValue(invoiceLine.AllowanceCharge.Amount.Value.ToString(Formatos.FormatoNumerico, Formato));
                    writer.WriteEndElement();
                    #endregion

                    writer.WriteEndElement();
                }
                #endregion

                #region TaxTotal
                {
                    foreach (var taxTotal in invoiceLine.TaxTotals)
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

                        #endregion

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

                        writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.Identifier); //VALOR OBTENIDO DE LA TABLA 5
                        writer.WriteEndElement();
                        #endregion ID

                        writer.WriteElementString("cbc:Percent", ext2.AdditionalMonetaryTotals[4].Percent.ToString(Formatos.FormatoNumerico, Formato));
                        //writer.WriteElementString("cbc:TaxExemptionReasonCode", taxTotal.TaxSubtotal.TaxCategory.TaxExemptionReasonCode);
                        writer.WriteStartElement("cbc:TaxExemptionReasonCode");
                        writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
                        writer.WriteAttributeString("listName", "Afectacion del IGV");
                        writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07");
                        writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.TaxExemptionReasonCode);
                        writer.WriteEndElement();

                        if (!string.IsNullOrEmpty(taxTotal.TaxSubtotal.TaxCategory.TierRange))
                            writer.WriteElementString("cbc:TierRange", taxTotal.TaxSubtotal.TaxCategory.TierRange);

                        #region TaxScheme
                        {
                            writer.WriteStartElement("cac:TaxScheme");

                            // writer.WriteElementString("cbc:ID", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id);
                            #region ID
                            writer.WriteStartElement("cbc:ID");
                            writer.WriteAttributeString("schemeID", "UN/ECE 5153");
                            writer.WriteAttributeString("schemeAgencyID", "6");
                            //writer.WriteAttributeString("schemeAgencyName", "United Nations Economic Commission for Europe");

                            writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id); //VALOR OBTENIDO DE LA TABLA 5
                            writer.WriteEndElement();
                            #endregion ID
                            writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
                            writer.WriteElementString("cbc:TaxTypeCode", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);

                            writer.WriteEndElement();
                        }
                        #endregion

                        writer.WriteEndElement();
                        #endregion

                        writer.WriteEndElement();
                        #endregion

                        writer.WriteEndElement();
                    }
                }
                #endregion

                #region Item
                writer.WriteStartElement("cac:Item");

                #region Description
                writer.WriteElementString("cbc:Description", invoiceLine.Item.Description);
                //writer.WriteStartElement("cbc:Description");
                //writer.WriteCData(invoiceLine.Item.Description);
                //writer.WriteEndElement();
                #endregion

                #region SellersItemIdentification
                writer.WriteStartElement("cac:SellersItemIdentification");
                writer.WriteElementString("cbc:ID", invoiceLine.Item.SellersItemIdentification.Id);
                writer.WriteEndElement();
                #endregion


                #region CommodityClassification
                if (!string.IsNullOrEmpty(invoiceLine.ItemClassificationCode))
                {
                    writer.WriteStartElement("cac:CommodityClassification");
                    writer.WriteStartElement("cbc:ItemClassificationCode");
                    writer.WriteAttributeString("listID", "UNSPSC");
                    writer.WriteAttributeString("listAgencyName", "GS1 US");
                    writer.WriteAttributeString("listName", "Item Classification");
                    writer.WriteValue(invoiceLine.ItemClassificationCode);//82141601-SERVICIOS FOTOGRAFICOS, MONTAJE Y ENMARCADO	82141602 - MONTAJE DE EXPOSICION DE ARTICULOS
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                #endregion CommodityClassification

                #region AdditionalItemProperty 
                if (!string.IsNullOrEmpty(invoiceLine.Item.AdditionalItemIdentification.Id))
                {
                    writer.WriteStartElement("cac:AdditionalItemProperty");
                    writer.WriteStartElement("cbc:Name");
                    writer.WriteValue(invoiceLine.Item.AdditionalItemIdentification.Id);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                #endregion

                writer.WriteEndElement();
                #endregion

                #region Price
                writer.WriteStartElement("cac:Price");

                writer.WriteStartElement("cbc:PriceAmount");
                writer.WriteAttributeString("currencyID", invoiceLine.Price.PriceAmount.CurrencyId);
                writer.WriteString(invoiceLine.Price.PriceAmount.Value.ToString(Formatos.FormatoNumerico, Formato));
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
            }
            #endregion
        }
    }
}