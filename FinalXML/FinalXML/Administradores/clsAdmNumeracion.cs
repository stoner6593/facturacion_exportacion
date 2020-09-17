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
    
    public class clsAdmNumeracion
    {
        INumeracion MNum = new MysqlNumeracion();
        public Boolean ActualizaNumeracion(clsNumeracion Numeracion)
        {
           
           return MNum.ActualizaNumeracion(Numeracion);

        }

        public clsNumeracion  BuscaNumeracion(String TipoDocumento)
         {
            try
            {
                return MNum.BuscaNumeracion(TipoDocumento);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }


        public clsNumeracion BuscaNumeracion2(Int32 IndexTipoDocumento)
        {

              return MNum.BuscaNumeracion2(IndexTipoDocumento);


        }

        public clsNumeracion BuscaNumeracionFac()
        {
            try
            {
                return MNum.BuscaNumeracionFac();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsNumeracion BuscaNumeracionDocBaja(String TipoDocumento)
        {
            try
            {
                return MNum.BuscaNumeracionDocBaja(TipoDocumento);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }


        public DataTable Listar()
        {
            return MNum.Listar();
        }


        public List<clsNumeracion> listar_Numeracion() {

            return MNum.listar_Numeracion();
        }
    }
   
}
