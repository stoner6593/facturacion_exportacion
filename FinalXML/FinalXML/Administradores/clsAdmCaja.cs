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
    public class clsAdmCaja
    {
        private ICaja icaja = new MysqlCaja();
        public int buscar_caja_abierta(clsUsuario usuario) {

            return icaja.buscar_caja_abierta(usuario);
        }

        public int registrar_caja(clsCaja caja) {

            return icaja.registrar_caja(caja);
        }

        public DataTable listar_caja_apertura() {

            return icaja.listar_caja_apertura();
        }

        public int anular_caja(clsCaja caja) {

            return icaja.anular_caja(caja);
        }

        public DataTable listar_caja_movimiento(clsCaja caja) {

            return icaja.listar_caja_movimiento(caja);
        }

        public clsCaja total_caja(clsCaja caja) {

            return icaja.total_caja(caja);
        }

        public clsCaja buscar_caja_cerrada(clsCaja caja) {

            return icaja.buscar_caja_cerrada(caja);
        }

        public int cerrar_caja(clsCaja caja) {

            return icaja.cerrar_caja(caja);
        }

        public DataSet reporte_caja_movimiento(clsCaja caja) {

            return icaja.reporte_caja_movimiento(caja);
        }

        public DataTable listar_caja_cerrada(DateTime fechaini, DateTime fechafin) {

            return icaja.listar_caja_cerrada(fechaini, fechafin);
        }

        public DataTable listar_movimiento_caja_xcomprobante(clsCaja caja, string comprobante) {

            return icaja.listar_movimiento_caja_xcomprobante(caja, comprobante);
        }
    }
}
