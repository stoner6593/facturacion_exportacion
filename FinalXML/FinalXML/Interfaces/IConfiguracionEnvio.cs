using FinalXML.Administradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Interfaces
{
    interface IConfiguracionEnvio
    {
        int registrar_configuracionenvio(clsConfiguracionEnvio config);
        int actualizar_configuracionenvio(clsConfiguracionEnvio config);
        clsConfiguracionEnvio listar_configuracionenvio();
    }
}
