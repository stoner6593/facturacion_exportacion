using FinalXML.Conexion;
using FinalXML.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Entidades;

namespace FinalXML.InterMySql
{
    class MysqlTipoUsuario:ITipoUsuario
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        public List<clsTipoUsuario> listar_tipo_usuario()
        {
            List<clsTipoUsuario> lista_tipousuario = null;
            clsTipoUsuario tipousuario = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("listar_tipo_usuario", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    lista_tipousuario = new List<clsTipoUsuario>();

                    while (dr.Read())
                    {
                        tipousuario = new clsTipoUsuario()
                        {
                            Idtipousuario = (int)dr["idtipousuario"],
                            Descripcion = (string)dr["descripcion"],                
                        };

                        lista_tipousuario.Add(tipousuario);
                    }
                }
                return lista_tipousuario;
            }
            catch (MySqlException ex)
            {
                return lista_tipousuario;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
