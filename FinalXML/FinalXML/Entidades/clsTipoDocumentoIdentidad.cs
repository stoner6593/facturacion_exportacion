using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    public class clsTipoDocumentoIdentidad
    {
        private int idtipodocumentoidentidad;
        private string descripcion;
        private string codsunat;
        private int estado;

        public int Idtipodocumentoidentidad
        {
            get
            {
                return idtipodocumentoidentidad;
            }

            set
            {
                idtipodocumentoidentidad = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string Codsunat
        {
            get
            {
                return codsunat;
            }

            set
            {
                codsunat = value;
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
