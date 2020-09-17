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
    class clsAdmEmpresa
    {
        private IEmpresa iempre = new MysqlEmpresa();
        public clsEmpresa listar_empresa() {

            return iempre.listar_empresa();
        }
    }
}
