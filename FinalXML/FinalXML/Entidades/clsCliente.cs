using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    public class clsCliente
    {
        private int idcliente;
        private clsTipoDocumentoIdentidad tipodocumentoidentidad;
        private string nombreyapellido;
        private string documento;
        private string direccion;
        private int estado;
        private List<clsPlaca> lista_placa;

        public int Idcliente
        {
            get
            {
                return idcliente;
            }

            set
            {
                idcliente = value;
            }
        }

        public clsTipoDocumentoIdentidad Tipodocumentoidentidad
        {
            get
            {
                return tipodocumentoidentidad;
            }

            set
            {
                tipodocumentoidentidad = value;
            }
        }

        public string Nombreyapellido
        {
            get
            {
                return nombreyapellido;
            }

            set
            {
                nombreyapellido = value;
            }
        }

        public string Documento
        {
            get
            {
                return documento;
            }

            set
            {
                documento = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
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

        internal List<clsPlaca> Lista_placa
        {
            get
            {
                return lista_placa;
            }

            set
            {
                lista_placa = value;
            }
        }
    }
}
