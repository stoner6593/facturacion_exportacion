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
    class clsAdmPlaca
    {
        private IPlaca iplaca = new MysqlPlaca();

        public int registrar_placa(clsPlaca placa) {

            return iplaca.registrar_placa(placa);
        }

        public int actualizar_placa(clsPlaca placa) {

            return iplaca.actualizar_placa(placa);
        }

        public DataTable listar_placa_xidcliente(clsCliente cliente) {

            return iplaca.listar_placa_xidcliente(cliente);
        }

    }
}
