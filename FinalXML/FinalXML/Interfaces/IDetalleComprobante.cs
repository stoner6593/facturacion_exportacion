using FinalXML.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinApp.Comun.Dto.Modelos;
namespace FinalXML.Interfaces
{
    interface IDetalleComprobante
    {

        Boolean insertdetalle(int repo,DetalleDocumento Detalle);
        Boolean updatedetalle(DetalleDocumento Detalle);
        Boolean anuladetalle(int CodigoDetalle);
        DataTable listarxcomprobante(int idcomprobante);

    }
}
