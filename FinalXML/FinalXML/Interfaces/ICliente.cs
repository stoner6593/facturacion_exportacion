using FinalXML.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Interfaces
{
    interface ICliente
    {
        clsCliente buscar_clientexnumerodocumento(clsCliente cliente);
        int registrar_cliente(clsCliente cliente);
        int actualizar_cliente(clsCliente cliente);
        DataTable buscar_clientexnombreyapellido(clsCliente cliente);
        DataTable listar_cliente();
        clsCliente listar_cliente_xnumeroplaca(clsPlaca placa);
    }
}
