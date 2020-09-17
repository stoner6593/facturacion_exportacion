using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Administradores
{
    class clsConfiguracionEnvio
    {
        private int configuracionid;
        private int estadoenvio;
        private string pcorigen;
        private string usuariopc;

        public int Configuracionid
        {
            get
            {
                return configuracionid;
            }

            set
            {
                configuracionid = value;
            }
        }

        public int Estadoenvio
        {
            get
            {
                return estadoenvio;
            }

            set
            {
                estadoenvio = value;
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
    }
}
