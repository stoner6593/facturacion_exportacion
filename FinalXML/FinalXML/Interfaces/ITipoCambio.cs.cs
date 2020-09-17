using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Entidades;
using System.Data;

namespace FinalXML.Interfaces
{
    interface ITipoCambio
    {

        Boolean Insert(clsTipoCambio NuevoTipoCambio);
        Boolean Update(clsTipoCambio TipoCambio);
        Boolean Delete(Int32 Codigo);

        clsTipoCambio CargaTipoCambio(DateTime Fecha, Int32 codMoneda);
        Boolean VerificaTCfecha(DateTime Fecha);
        DataTable ListaTipoCambios(Int32 Mes, Int32 Año);
    }
}
