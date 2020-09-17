using FinalXML.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Interfaces
{
    interface IComprobante
    {
        DataTable listar_comprobante_xfecha(DateTime fecha_inicio, DateTime fecha_fin, int estado);
        int anular_comprobante(clsComprobante comprobante);
        DataTable listar_comprobante_xfecha_xnumero(DateTime fecha_inicio, DateTime fecha_fin, int estado, string numero);
        DataTable listar_reporte(DateTime fecha_inicio, DateTime fecha_fin, int estado);

    }
}
