using FinalXML.Entidades;
using FinalXML.Interfaces;
using FinalXML.InterMySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Administradores
{
    class clsAdmTipoUsuario
    {
        private ITipoUsuario itipousu = new MysqlTipoUsuario();

        public List<clsTipoUsuario> listar_tipo_usuario() {

            return itipousu.listar_tipo_usuario();
        }
    }
}
