using FinalXML.Administradores;
using FinalXML.Interfaces;
using FinalXML.InterMySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.controlador
{
    class CclsConfiguracionEnvio
    {
        private IConfiguracionEnvio iconfig = new MysqlConfiguracionEnvio();

        public clsConfiguracionEnvio listar_configuracionenvio() {

            return iconfig.listar_configuracionenvio();
        }

        public int registrar_configuracionenvio(clsConfiguracionEnvio config) {

            return iconfig.registrar_configuracionenvio(config);
        }

        public int actualizar_configuracionenvio(clsConfiguracionEnvio config) {

            return iconfig.actualizar_configuracionenvio(config);
        }
    }
}
