using FinalXML.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Interfaces
{
    interface IPlaca
    {
        int registrar_placa(clsPlaca placa);
        int actualizar_placa(clsPlaca placa);
        DataTable listar_placa_xidcliente(clsCliente cliente);

    }
}
