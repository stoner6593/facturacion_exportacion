using FinalXML.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Interfaces
{
    interface IUsuario
    {
        int registrar_usuario(clsUsuario usuario);
        int actualizar_usuario(clsUsuario usuario);
        DataTable listar_usuario();
        clsUsuario validar_usuario(clsUsuario usuario);
    }
}
