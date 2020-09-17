using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    class clsDetalleComprobante
    {
        private int iddetallec;
        private clsComprobante comprobante;
        private string nombreproducto;
        private decimal cantidad;
        private clsUnidadMedida unidad;
        private decimal subtotal;
        private decimal igv;
        private decimal total;
        private int estado;
        private DateTime fecharegistro;

        public clsDetalleComprobante(int iddetallec, clsComprobante comprobante, string nombreproducto, decimal cantidad, clsUnidadMedida unidad, decimal subtotal, decimal igv, decimal total, int estado, DateTime fecharegistro)
        {
            this.iddetallec = iddetallec;
            this.comprobante = comprobante;
            this.nombreproducto = nombreproducto;
            this.cantidad = cantidad;
            this.unidad = unidad;
            this.subtotal = subtotal;
            this.igv = igv;
            this.total = total;
            this.estado = estado;
            this.fecharegistro = fecharegistro;
        }

        public clsDetalleComprobante() { }


        public int Iddetallec
        {
            get
            {
                return iddetallec;
            }

            set
            {
                iddetallec = value;
            }
        }

        internal clsComprobante Comprobante
        {
            get
            {
                return comprobante;
            }

            set
            {
                comprobante = value;
            }
        }

        public string Nombreproducto
        {
            get
            {
                return nombreproducto;
            }

            set
            {
                nombreproducto = value;
            }
        }

        public decimal Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public clsUnidadMedida Unidad
        {
            get
            {
                return unidad;
            }

            set
            {
                unidad = value;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return subtotal;
            }

            set
            {
                subtotal = value;
            }
        }

        public decimal Igv
        {
            get
            {
                return igv;
            }

            set
            {
                igv = value;
            }
        }

        public decimal Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public DateTime Fecharegistro
        {
            get
            {
                return fecharegistro;
            }

            set
            {
                fecharegistro = value;
            }
        }

       







    }
}
