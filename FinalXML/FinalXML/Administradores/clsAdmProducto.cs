using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Interfaces;
using FinalXML.Administradores;
using FinalXML.InterMySql;
using FinalXML.Entidades;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalXML.Administradores
{
    public class clsAdmProducto
    {
        IProducto MPro = new MysqlProducto();

        public clsProducto Insertar(clsProducto oProducto)
        {
            return MPro.Insertar(oProducto);
        }

        public clsProducto Actualizar(clsProducto oProducto)
        {
            return MPro.Actualizar(oProducto);
        }

        public clsProducto Buscar(Int32 codigo)
        {
            return MPro.Buscar(codigo);
        }

        public DataTable Listar()
        {
            return MPro.Listar();
        }

        public DataTable Busqueda(string descripcion)
        {
            return MPro.Busqueda(descripcion);
        }


        public void Eliminar(Int32 codigo)
        {
            MPro.Eliminar(codigo);
        }

        public DataTable Listar_xnombre(clsProducto producto) {

            return MPro.Listar_xnombre(producto);
        }
    }
}
