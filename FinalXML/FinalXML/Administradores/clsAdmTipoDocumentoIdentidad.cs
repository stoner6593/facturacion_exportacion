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
    class clsAdmTipoDocumentoIdentidad
    {
        private ITipoDocumentoIdentidad itipodoc = new MysqlTipoDocumentoIdentidad();

        public List<clsTipoDocumentoIdentidad> listar_tipo_documento_identidad() {

            return itipodoc.listar_tipo_documento_identidad();
        }
    }
}
