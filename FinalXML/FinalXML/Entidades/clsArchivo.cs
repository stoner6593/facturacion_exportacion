using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Administradores
{
    class clsArchivo
    {
        private int archivoid;
        private clsRepositorio repositorio;
        private byte[] xml;
        private byte[] pdf;
        private byte[] zip;

        public int Archivoid
        {
            get
            {
                return archivoid;
            }

            set
            {
                archivoid = value;
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

        public byte[] Xml
        {
            get
            {
                return xml;
            }

            set
            {
                xml = value;
            }
        }

        public byte[] Pdf
        {
            get
            {
                return pdf;
            }

            set
            {
                pdf = value;
            }
        }

        public byte[] Zip
        {
            get
            {
                return zip;
            }

            set
            {
                zip = value;
            }
        }
    }
}
