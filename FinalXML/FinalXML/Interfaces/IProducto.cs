using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Entidades;
using System.Data;

namespace FinalXML.Interfaces
{
    interface IProducto
    {
        clsProducto Insertar(clsProducto oProducto);
        clsProducto Actualizar(clsProducto oProducto);

        void Eliminar(Int32 codigo);

        DataTable Listar();

        DataTable Busqueda(string descripcion);

        clsProducto Buscar(Int32 codigo);

        DataTable Listar_xnombre(clsProducto producto);
    }

        
}
