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
    class MysqlPlaca:IPlaca
    {
        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction tra = null;
        private DataTable tabla = null;

        public int registrar_placa(clsPlaca placa)
        {
            int id = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("registrar_placa", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_idcliente", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_numero", MySqlDbType.VarChar));

                cmd.Parameters[0].Value = placa.Cliente.Idcliente;
                cmd.Parameters[1].Value = placa.Numero;

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr["_id"]);
                    }
                    dr.Close();
                }
                tra.Commit();
                return id;
            }
            catch (MySqlException ex)
            {
                id = -1;
                tra.Rollback();
                return id;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public int actualizar_placa(clsPlaca placa)
        {
            int filas_afectadas = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("actualizar_placa", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_idplaca", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_numero", MySqlDbType.VarChar));

                cmd.Parameters[0].Value = placa.Idplaca;
                cmd.Parameters[1].Value = placa.Numero;


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
                filas_afectadas = -1;
                tra.Rollback();
                return filas_afectadas;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable listar_placa_xidcliente(clsCliente cliente)
        {
            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_placa_xidcliente", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                adap = new MySqlDataAdapter(cmd);
            
                cmd.Parameters.Add(new MySqlParameter("@_idcliente", MySqlDbType.Int32));

                cmd.Parameters[0].Value = cliente.Idcliente;
                adap.Fill(tabla);
            }

            return tabla;
        }
    }
}
