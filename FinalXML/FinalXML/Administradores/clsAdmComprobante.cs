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
    class clsAdmComprobante
    {
        private IComprobante icompro = new MysqlComprobante();

        public DataTable listar_comprobante_xfecha(DateTime fecha_inicio, DateTime fecha_fin, int estado) {

            return icompro.listar_comprobante_xfecha(fecha_inicio, fecha_fin, estado);
        }

        public int anular_comprobante(clsComprobante comprobante) {

            return icompro.anular_comprobante(comprobante);
        }

        public DataTable listar_comprobante_xfecha_xnumero(DateTime fecha_inicio, DateTime fecha_fin, int estado, string numero) {

            return icompro.listar_comprobante_xfecha_xnumero(fecha_inicio, fecha_fin, estado, numero);
        }

        public DataTable listar_reporte(DateTime fecha_inicio, DateTime fecha_fin, int estado)
        {
            return icompro.listar_reporte(fecha_inicio,fecha_fin,estado);
        }
    }
}
