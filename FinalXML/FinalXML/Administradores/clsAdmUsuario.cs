using FinalXML.Entidades;
using FinalXML.Interfaces;
using FinalXML.InterMySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Administradores
{
    class clsAdmUsuario
    {
        private IUsuario iusu = new MysqlUsuario();
        public int registrar_usuario(clsUsuario usuario) {

            return iusu.registrar_usuario(usuario);
        }

        public int actualizar_usuario(clsUsuario usuario) {

            return iusu.actualizar_usuario(usuario);
        }

        public DataTable listar_usuario() {

            return iusu.listar_usuario();
        }

        public clsUsuario validar_usuario(clsUsuario usuario) {

            return iusu.validar_usuario(usuario);
        }
    }
}
