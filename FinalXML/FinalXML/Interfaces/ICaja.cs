using FinalXML.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Interfaces
{
    interface ICaja
    {
        int buscar_caja_abierta(clsUsuario usuario);
        int registrar_caja(clsCaja caja);
        DataTable listar_caja_apertura();
        int anular_caja(clsCaja caja);
        DataTable listar_caja_movimiento(clsCaja caja);
        clsCaja total_caja(clsCaja caja);
        clsCaja buscar_caja_cerrada(clsCaja caja);
        int cerrar_caja(clsCaja caja);
        DataSet reporte_caja_movimiento(clsCaja caja);
        DataTable listar_caja_cerrada(DateTime fechaini, DateTime fechafin);
        DataTable listar_movimiento_caja_xcomprobante(clsCaja caja, string comprobante);
    }
}
