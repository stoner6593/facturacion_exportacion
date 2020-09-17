using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    public class clsEmpresa
    {
        private string ruc;
        private string usuariosol;
        private string clavesol;
        private string rutacertificado;
        private string clavecertificado;
        private string urlenvio;

        public string Ruc
        {
            get
            {
                return ruc;
            }

            set
            {
                ruc = value;
            }
        }

        public string Usuariosol
        {
            get
            {
                return usuariosol;
            }

            set
            {
                usuariosol = value;
            }
        }

        public string Clavesol
        {
            get
            {
                return clavesol;
            }

            set
            {
                clavesol = value;
            }
        }

        public string Rutacertificado
        {
            get
            {
                return rutacertificado;
            }

            set
            {
                rutacertificado = value;
            }
        }

        public string Clavecertificado
        {
            get
            {
                return clavecertificado;
            }

            set
            {
                clavecertificado = value;
            }
        }

        public string Urlenvio
        {
            get
            {
                return urlenvio;
            }

            set
            {
                urlenvio = value;
            }
        }
    }
}
