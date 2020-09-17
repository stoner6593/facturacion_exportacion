using FinalXML.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Entidades;
using FinalXML.Conexion;
using MySql.Data.MySqlClient;
using System.Data;

namespace FinalXML.InterMySql
{
    class MysqlTipoDocumentoIdentidad : ITipoDocumentoIdentidad
    {
        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction tra = null;
        private DataTable tabla = null;
        public List<clsTipoDocumentoIdentidad> listar_tipo_documento_identidad()
        {
            List<clsTipoDocumentoIdentidad> lista_tipodociden = null;
            clsTipoDocumentoIdentidad tipodociden = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("listar_tipo_documento_identidad", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    lista_tipodociden = new List<clsTipoDocumentoIdentidad>();

                    while (dr.Read())
                    {
                        tipodociden = new clsTipoDocumentoIdentidad()
                        {
                            Idtipodocumentoidentidad = (int)dr["idtipodocumentoidentidad"],
                            Descripcion = (string)dr["descripcion"],
                            Codsunat = (string)dr["codsunat"]
                        };

                        lista_tipodociden.Add(tipodociden);
                    }
                }
                return lista_tipodociden;
            }
            catch (MySqlException ex)
            {
                return lista_tipodociden;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
