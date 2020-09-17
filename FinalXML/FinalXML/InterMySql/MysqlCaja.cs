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
    class MysqlCaja:ICaja
    {
        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction tra = null;
        private DataTable tabla = null;
        private DataSet data = null;
        private Herramientas her = new Herramientas();
        private string ruta = "";

        public int buscar_caja_abierta(clsUsuario usuario)
        {
            int existe = 0;

            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("buscar_caja_abierta", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_usuarioid", MySqlDbType.Int32));
                cmd.Parameters[0].Value = usuario.Idusuario;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        existe = Convert.ToInt32(dr["_cajaid"]);
                    }
                }
                return existe;
            }
            catch (MySqlException ex)
            {
                return existe;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public int registrar_caja(clsCaja caja)
        {
            int id = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("registrar_caja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;

                cmd.Parameters.Add(new MySqlParameter("@_montoapertura", MySqlDbType.Decimal));
                cmd.Parameters.Add(new MySqlParameter("@_usuarioid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_estado", MySqlDbType.Int32));                

                cmd.Parameters[0].Value = caja.Montoapertura;
                cmd.Parameters[1].Value = caja.Usuario.Idusuario;
                cmd.Parameters[2].Value = caja.Estado;
              

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

        public DataTable listar_caja_apertura()
        {

            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_caja_aperturada", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public int anular_caja(clsCaja caja)
        {
            int filas_afectadas = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("anular_caja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_cajaid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_idusuario", MySqlDbType.Int32));
                cmd.Parameters[0].Value = caja.Cajaid;
                cmd.Parameters[1].Value = caja.Usuario.Idusuario;

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

        public DataTable listar_caja_movimiento(clsCaja caja)
        {
            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_movimiento_caja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_cajaid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_estado", MySqlDbType.Int32));
                cmd.Parameters[0].Value = caja.Cajaid;
                cmd.Parameters[1].Value = caja.Estado;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public clsCaja total_caja(clsCaja caja)
        {
            clsCaja _caja = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("totales_caja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_cajaid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_estado", MySqlDbType.Int32));

                cmd.Parameters[0].Value = caja.Cajaid;
                cmd.Parameters[1].Value = caja.Estado;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        _caja = new clsCaja()
                        {

                            Cajaid = (int)dr["cajaid"],
                            Montoapertura = (decimal)dr["montoapertura"],
                            Montocierre = (decimal)dr["montocierre"],
                            Totalefectivo = (decimal)dr["totalefectivo"],
                            Totaldeposito = (decimal)dr["totaldeposito"],
                            Totaltransferencia = (decimal)dr["totaltransferencia"],
                            Totaltarjeta = (decimal)dr["totaltarjeta"],
                            Totalnotacredito = (decimal)dr["totalnotacredito"],
                            Totaldisponible = (decimal)dr["totaldisponible"]

                        };
                    }
                }
                return _caja;
            }
            catch (MySqlException ex)
            {
                return _caja;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsCaja buscar_caja_cerrada(clsCaja caja)
        {
            clsCaja _caja = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("buscar_caja_cerrada", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_cajaid", MySqlDbType.Int32));

                cmd.Parameters[0].Value = caja.Cajaid;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        _caja = new clsCaja()
                        {

                            Cajaid = (int)dr["cajaid"],

                        };
                    }
                }
                return _caja;
            }
            catch (MySqlException ex)
            {
                return _caja;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public int cerrar_caja(clsCaja caja)
        {
            int filas_afectadas = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("cerrar_caja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_cajaid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_idusuario", MySqlDbType.Int32));
                cmd.Parameters[0].Value = caja.Cajaid;
                cmd.Parameters[1].Value = caja.Usuario.Idusuario;

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

        public DataSet reporte_caja_movimiento(clsCaja caja)
        {
            try
            {
                con.conectarBD();
                data = new DataSet();
                cmd = new MySqlCommand("reporte_movimiento_caja", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_cajaid", MySqlDbType.Int32));

                cmd.Parameters[0].Value = caja.Cajaid;

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(data, "cierre_caja");

                ruta = her.GetResourcesPath4() + "\\cajacierre.xml";
                data.WriteXml(ruta, XmlWriteMode.WriteSchema);

                return data;
            }
            catch (MySqlException ex)
            {
                return data;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable listar_caja_cerrada(DateTime fechaini, DateTime fechafin)
        {
            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_caja_cerrada", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_fechaini", MySqlDbType.Date));
                cmd.Parameters.Add(new MySqlParameter("@_fechafin", MySqlDbType.Date));

                cmd.Parameters[0].Value = fechaini;
                cmd.Parameters[1].Value = fechafin;

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public DataTable listar_movimiento_caja_xcomprobante(clsCaja caja, string comprobante)
        {
            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_movimiento_caja_xcomprobante", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_cajaid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_estado", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_comprobante", MySqlDbType.VarChar));
                cmd.Parameters[0].Value = caja.Cajaid;
                cmd.Parameters[1].Value = caja.Estado;
                cmd.Parameters[2].Value = comprobante;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }
    }
}
