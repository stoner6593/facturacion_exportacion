using FinalXML.Administradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    class clsComprobante
    {
        private int idcomprobante;
        private string tipocomprobante;
        private clsRepositorio repositorio;
        private string numero;
        private DateTime fechaemision;
        private decimal total;
        private DateTime fechacancelado;
        private int situacionpago;
        private decimal montocancelado;
        private string usuariopc;
        private int estado;

        public int Idcomprobante
        {
            get
            {
                return idcomprobante;
            }

            set
            {
                idcomprobante = value;
            }
        }

        public string Tipocomprobante
        {
            get
            {
                return tipocomprobante;
            }

            set
            {
                tipocomprobante = value;
            }
        }

        internal clsRepositorio Repositorio
        {
            get
            {
                return repositorio;
            }

            set
            {
                repositorio = value;
            }
        }

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public DateTime Fechaemision
        {
            get
            {
                return fechaemision;
            }

            set
            {
                fechaemision = value;
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

        public DateTime Fechacancelado
        {
            get
            {
                return fechacancelado;
            }

            set
            {
                fechacancelado = value;
            }
        }

        public int Situacionpago
        {
            get
            {
                return situacionpago;
            }

            set
            {
                situacionpago = value;
            }
        }

        public decimal Montocancelado
        {
            get
            {
                return montocancelado;
            }

            set
            {
                montocancelado = value;
            }
        }

        public string Usuariopc
        {
            get
            {
                return usuariopc;
            }

            set
            {
                usuariopc = value;
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
    }
}
