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
    class MysqlEmpresa:IEmpresa
    {
        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction tra = null;
        private DataTable tabla = null;

        public clsEmpresa listar_empresa()
        {
            clsEmpresa empresa = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("listar_empresa", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        empresa = new clsEmpresa()
                        {                           
                            Ruc = (string)dr["ruc"],
                            Usuariosol = (string)dr["usuariosol"],
                            Clavesol = (string)dr["clavesol"],
                            Rutacertificado=(string)dr["nbcertificado"],
                            Clavecertificado=(string)dr["ccerfitificado"],
                            Urlenvio=(string)dr["urlenvio"]
                        };
                    }
                }
                return empresa;
            }
            catch (MySqlException ex)
            {
                return empresa;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
