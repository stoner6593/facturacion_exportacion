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
    class clsAdmCliente
    {
        private ICliente icli = new MysqlCliente();

        public int actualizar_cliente(clsCliente cliente) {

            return icli.actualizar_cliente(cliente);
        }

        public DataTable buscar_clientexnombreyapellido(clsCliente cliente) {

            return icli.buscar_clientexnombreyapellido(cliente);
        }

        public clsCliente buscar_clientexnumerodocumento(clsCliente cliente) {

            return icli.buscar_clientexnumerodocumento(cliente);
        }

        public DataTable listar_cliente() {

            return icli.listar_cliente();
        }

        public int registrar_cliente(clsCliente cliente) {

            return icli.registrar_cliente(cliente);
        }

        public clsCliente listar_cliente_xnumeroplaca(clsPlaca placa) {

            return icli.listar_cliente_xnumeroplaca(placa);
        }
    }
}
