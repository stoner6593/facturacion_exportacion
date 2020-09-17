﻿using Newtonsoft.Json;
using System.Collections.Generic;
using WinApp.Comun.Dto.Contratos;

namespace WinApp.Comun.Dto.Modelos
{
    public class DocumentoElectronico : IDocumentoElectronico
    {
        [JsonProperty(Required = Required.Always)]
        public string IdDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Contribuyente Emisor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Contribuyente Receptor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FechaEmision { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Moneda { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string TipoOperacion { get; set; }

        public string IssueTime { get; set; }
        public decimal Gravadas { get; set; }

        public decimal Gratuitas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exoneradas { get; set; }

        public decimal DescuentoGlobal { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<DetalleDocumento> Items { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalVenta { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosTributos { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string MontoEnLetras { get; set; }

        public string PlacaVehiculo { get; set; }

        public decimal MontoPercepcion { get; set; }

        public decimal MontoDetraccion { get; set; }

        public List<DatoAdicional>  DatoAdicionales { get; set; }
        
        public List<PaymentTerms> TerminosPagos { get; set; }

        public PaymentMeans MediosPago { get; set; }

        public string TipoDocAnticipo { get; set; }

        public string DocAnticipo { get; set; }

        public string MonedaAnticipo { get; set; }

        public decimal MontoAnticipo { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public DatosGuia DatosGuiaTransportista { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public List<DocumentoRelacionado> Relacionados { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public List<DocumentoRelacionado> OtrosDocumentosRelacionados { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public List<Discrepancia> Discrepancias { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal CalculoIgv { get; set; }

        public decimal CalculoIsc { get; set; }

        public DocumentoPercepcion DocumentoPercepcion { get; set; }
        public DocumentoRetencion DocumentoRetencion { get; set; }
        public Exportacion Exportacion { get; set; }

        public decimal CalculoDetraccion { get; set; }
        public decimal SubTotalVenta { get; set; }
        public string LineCountNumeric { get; set; }
        public string FirmaDigital { get; set; }
        public string NumGuia { get; set; }
        public string Glosa { get; set; }
        public string ResumenFirma { get; set; }
        public string Total2 { get; set; }
        public string Cajas { get; set; }
        public string Imcoterm { get; set; }
        public string OrderReference { get; set; }
        public string AdditionalItemProperty { get; set; }
        public decimal MultiplierFactorNumeric  { get; set;}
        public string NumGuiaTrans { get; set; }
        public string OrdCompra { get; set; }
        public string OrdServicios { get; set; }
        public string MontoEnLetrasDolares { get; set; }
        public decimal Cargos { get; set; }

  

        /*Exportación*/
        public string PuestoOrigen { get; set; }
        public string PuestoDestino { get; set; }
        public string BL { get; set; }
        public string Poliza { get; set; }
        public string CC { get; set; }
        public string CondicionVenta { get; set; }
        public string Asegurado { get; set; }
        public string Intermedio { get; set; }
        public string PesoNeto { get; set; }
        public string PesoBruto { get; set; }
        public string Drawback { get; set; }
        public string Booking { get; set; }




        public DocumentoElectronico()
        {
       
           
            Emisor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.
            };
            Receptor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.
            };
            CalculoIgv = 0.00m;
            CalculoIsc = 0.10m;
            CalculoDetraccion = 0.04m;
            Items = new List<DetalleDocumento>();
            DatoAdicionales = new List<DatoAdicional>();
            Relacionados = new List<DocumentoRelacionado>();
            OtrosDocumentosRelacionados = new List<DocumentoRelacionado>();
            Discrepancias = new List<Discrepancia>();
            TerminosPagos = new List<PaymentTerms>();
            MediosPago = new PaymentMeans();
            TipoDocumento = "01"; // Factura.
            TipoOperacion = "0101"; // Venta Interna.
            Moneda = "PEN"; // Soles.
            DocumentoPercepcion = new DocumentoPercepcion();
            Exportacion = new Exportacion();
        }
    }
}
