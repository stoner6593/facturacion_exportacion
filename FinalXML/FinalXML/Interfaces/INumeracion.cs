using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Entidades;
using System.Data;

namespace FinalXML.Interfaces
{
     interface INumeracion
    {
        Boolean ActualizaNumeracion(clsNumeracion Numeracion);
        clsNumeracion BuscaNumeracion(String Numeracion);
        clsNumeracion BuscaNumeracion2(Int32 IndexTipoDocumento);
        clsNumeracion BuscaNumeracionDocBaja(String Numeracion);
        clsNumeracion BuscaNumeracionFac();

        List<clsNumeracion> listar_Numeracion();
        DataTable Listar();

    }
}
