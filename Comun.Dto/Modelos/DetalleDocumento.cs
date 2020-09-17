﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace WinApp.Comun.Dto.Modelos
{
    public class DetalleDocumento
    {
        [JsonProperty(Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal Cantidad { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string UnidadMedida { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string CodigoItem { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Descripcion { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PrecioUnitario { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PrecioReferencial { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoPrecio { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoImpuesto { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal Impuesto { get; set; }

        public decimal ImpuestoSelectivo { get; set; }

        public decimal OtroImpuesto { get; set; }

        public decimal Descuento { get; set; }

        public string PlacaVehiculo { get; set; }

        public string ItemClassificationCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalVenta { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal Suma { get; set; }

        public List<PaymentTerms> TerminosPago { get; set; }
        public string CodDetraccion { get; set; }
        public string PorcentajeDetraccion { get; set; }
        public decimal MontoDetraccion { get; set; }
        public decimal SubTotalVenta { get; set; }
        public DetalleDocumento()
        {
            Id = 1;
            UnidadMedida = "NIU";
            TipoPrecio = "01";
            TipoImpuesto = "10";
            TerminosPago = new List<Modelos.PaymentTerms>();
        }
    }
}
