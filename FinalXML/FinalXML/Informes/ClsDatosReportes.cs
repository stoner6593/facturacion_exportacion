using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML
{
   public class ClsDatosReportes
    {
        public string IdDocumento { get; set; }

        public string FechaEmision { get; set; }
        public decimal Gravadas { get; set; }
        public decimal Gratuitas { get; set; }
        public decimal Inafectas { get; set; }
        public decimal Exoneradas { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal TotalIgv { get; set; }
        public decimal SubTotalVentas { get; set; }
        public string MontoEnLetras { get; set; }
        public string Moneda { get; set; }
        public string MonedaLetra { get; set; }
        public string MonedaLetraDolar { get; set; }
        public string TextoMoneda { get; set; }
        public string Logos { get; set; }


        public string Glosa { get; set; }
        public string Total2 { get; set; }
        public string NumeroCajas { get; set; }

        public string MontoDetracion { get; set; }
        public string CalculoDetracion { get; set; }
        public string NumGuia { get; set; }
        public string NumGuiaTrans { get; set; }
        public string OrdCompra { get; set; }
        public string OrdServicios { get; set; }
        public string Cajero { get; set; }

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
        public string Dracwback { get; set; }
        public string Booking { get; set; }





    }
}
