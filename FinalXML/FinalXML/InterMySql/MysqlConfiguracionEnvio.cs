using FinalXML.Administradores;
using FinalXML.Conexion;
using FinalXML.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.InterMySql
{
    class MysqlConfiguracionEnvio : IConfiguracionEnvio
    {
        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction tra=null;
        private DataTable tabla = null;

        public int registrar_configuracionenvio(clsConfiguracionEnvio config)
        {
            int id = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("registrar_configuracionenvio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_estadoenvio", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_pcorigen", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_usuariopc", MySqlDbType.VarChar));

                cmd.Parameters[0].Value = config.Estadoenvio;
                cmd.Parameters[1].Value = config.Pcorigen;
                cmd.Parameters[2].Value = config.Usuariopc;

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        id = Convert.ToInt32( dr["_id"]);                     
                    }
                    dr.Close();
                }
                tra.Commit();
                return id;
            }
            catch (MySqlException ex)
            {
                tra.Rollback();
                return id;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public int actualizar_configuracionenvio(clsConfiguracionEnvio config)
        {
            int filas_afectadas = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("actualizar_configuracionenvio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_configuracionid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_estadoenvio", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_pcorigen", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_usuariopc", MySqlDbType.VarChar));

                cmd.Parameters[0].Value = config.Configuracionid;
                cmd.Parameters[1].Value = config.Estadoenvio;
                cmd.Parameters[2].Value = config.Pcorigen;
                cmd.Parameters[3].Value = config.Usuariopc;

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        filas_afectadas = Convert.ToInt32(dr["_filas_afectadas"]);
                    }
                    dr.Close();
                }
                tra.Commit();
                return filas_afectadas;
            }
            catch (MySqlException ex)
            {
                tra.Rollback();
                return filas_afectadas;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsConfiguracionEnvio listar_configuracionenvio()
        {
            clsConfiguracionEnvio config = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("listar_configuracionnvio", con.conector);  
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        config = new clsConfiguracionEnvio() {
                            Configuracionid= (int)dr["configuracionid"],
                            Estadoenvio= (int)dr["estadoenvio"],
                        };                   
                    }
                }
                return config;
            }
            catch (MySqlException ex)
            {
                return config;
                throw ex;                
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
