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
    class MysqlComprobante:IComprobante
    {
        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction tra = null;
        private DataTable tabla = null;

        public DataTable listar_comprobante_xfecha(DateTime fecha_inicio, DateTime fecha_fin, int estado)
        {

            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_comprobante_xfecha", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_fechaini", MySqlDbType.Date));
                cmd.Parameters.Add(new MySqlParameter("@_fechafin", MySqlDbType.Date));
                cmd.Parameters.Add(new MySqlParameter("@_estado", MySqlDbType.Int32));

                cmd.Parameters[0].Value = fecha_inicio;
                cmd.Parameters[1].Value = fecha_fin;
                cmd.Parameters[2].Value = estado;

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public int anular_comprobante(clsComprobante comprobante)
        {
            int filas_afectadas = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("anular_comprobante", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_idcomprobante", MySqlDbType.Int32));              

                cmd.Parameters[0].Value = comprobante.Idcomprobante;      

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

        public DataTable listar_comprobante_xfecha_xnumero(DateTime fecha_inicio, DateTime fecha_fin, int estado, string numero)
        {
            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_comprobante_xfecha_xnumero", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_fechaini", MySqlDbType.Date));
                cmd.Parameters.Add(new MySqlParameter("@_fechafin", MySqlDbType.Date));
                cmd.Parameters.Add(new MySqlParameter("@_estado", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_numero", MySqlDbType.VarChar));

                cmd.Parameters[0].Value = fecha_inicio;
                cmd.Parameters[1].Value = fecha_fin;
                cmd.Parameters[2].Value = estado;
                cmd.Parameters[3].Value = numero;

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public DataTable listar_reporte(DateTime fecha_inicio, DateTime fecha_fin, int estado)
        {
            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_reporte", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_fechaini", MySqlDbType.Date));
                cmd.Parameters.Add(new MySqlParameter("@_fechafin", MySqlDbType.Date));
                cmd.Parameters.Add(new MySqlParameter("@_estado", MySqlDbType.Int32));

                cmd.Parameters[0].Value = fecha_inicio;
                cmd.Parameters[1].Value = fecha_fin;
                cmd.Parameters[2].Value = estado;

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }
    }
}
