using FinalXML.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Administradores
{
    class clsRepositorio
    {
        private int repositorioid;
        private string tipodocumento;
        private string serie;
        private string correlativo;
        private string comprobante;
        private DateTime fechaemision;
        private decimal monto;
        private int estadosunat;
        private string mensajesunat;
        private string nombredocxml;
        private string rutaxml;
        private string nombredocpdf;
        private string rutapdf;
        private string pcorigen;
        private string usuariopc;
        private clsArchivo archivo;
        private clsCliente cliente;

        public int Repositorioid
        {
            get
            {
                return repositorioid;
            }

            set
            {
                repositorioid = value;
            }
        }

       

        public string Serie
        {
            get
            {
                return serie;
            }

            set
            {
                serie = value;
            }
        }

        public string Correlativo
        {
            get
            {
                return correlativo;
            }

            set
            {
                correlativo = value;
            }
        }

        public string Comprobante
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

        public decimal Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public int Estadosunat
        {
            get
            {
                return estadosunat;
            }

            set
            {
                estadosunat = value;
            }
        }

        public string Mensajesunat
        {
            get
            {
                return mensajesunat;
            }

            set
            {
                mensajesunat = value;
            }
        }

        public string Nombredocxml
        {
            get
            {
                return nombredocxml;
            }

            set
            {
                nombredocxml = value;
            }
        }

        public string Rutaxml
        {
            get
            {
                return rutaxml;
            }

            set
            {
                rutaxml = value;
            }
        }

        public string Nombredocpdf
        {
            get
            {
                return nombredocpdf;
            }

            set
            {
                nombredocpdf = value;
            }
        }

        public string Rutapdf
        {
            get
            {
                return rutapdf;
            }

            set
            {
                rutapdf = value;
            }
        }

        public string Pcorigen
        {
            get
            {
                return pcorigen;
            }

            set
            {
                pcorigen = value;
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

        internal clsArchivo Archivo
        {
            get
            {
                return archivo;
            }

            set
            {
                archivo = value;
            }
        }

        public string Tipodocumento
        {
            get
            {
                return tipodocumento;
            }

            set
            {
                tipodocumento = value;
            }
        }

        public clsCliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }
    }
}
