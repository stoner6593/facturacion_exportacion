using FinalXML.Entidades;
using FinalXML.Interfaces;
using FinalXML.InterMySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinApp.Comun.Dto.Modelos;

namespace FinalXML.Administradores
{
    class clsAdmDetalleComprobante
    {
        private IDetalleComprobante detallecomp = new MysqlDetalleComprobante();

        public bool anuladetalle(int CodigoDetalle)
        {
            return detallecomp.anuladetalle(CodigoDetalle);
        }

        public bool insertdetalle(int repo,DetalleDocumento Detalle)
        {
            return detallecomp.insertdetalle(repo,Detalle);
        }

        public bool updatedetalle(DetalleDocumento Detalle)
        {
            return detallecomp.updatedetalle(Detalle);
        }

        public DataTable listarxcomprobante(int idcomprobante)
        {
            return detallecomp.listarxcomprobante(idcomprobante);
        }
    }
}
