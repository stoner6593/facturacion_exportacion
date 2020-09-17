using FinalXML.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Entidades;
using System.Data;
using FinalXML.Conexion;
using MySql.Data.MySqlClient;

namespace FinalXML.InterMySql
{
    class MysqlCliente : ICliente
    {
        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction tra = null;
        private DataTable tabla = null;
        public int actualizar_cliente(clsCliente cliente)
        {
            int filas_afectadas = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("actualizar_cliente", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_idcliente", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_idtipodocumentoidentidad", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_nombreyapellido", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_documento", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_direccion", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_estado", MySqlDbType.Int32));
            

                cmd.Parameters[0].Value = cliente.Idcliente;
                cmd.Parameters[1].Value = cliente.Tipodocumentoidentidad.Idtipodocumentoidentidad;
                cmd.Parameters[2].Value = cliente.Nombreyapellido;
                cmd.Parameters[3].Value = cliente.Documento;
                cmd.Parameters[4].Value = cliente.Direccion;
                cmd.Parameters[5].Value = cliente.Estado;              

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

        public DataTable buscar_clientexnombreyapellido(clsCliente cliente)
        {
            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("buscar_clientexnombreyapellido", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_nombreyapellido", MySqlDbType.VarChar));
                cmd.Parameters[0].Value = cliente.Nombreyapellido;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public clsCliente buscar_clientexnumerodocumento(clsCliente cliente)
        {
            clsCliente cli = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("buscar_clientexnumerodocumento", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_numero", MySqlDbType.VarChar));
                cmd.Parameters[0].Value = cliente.Documento;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cli = new clsCliente()
                        {

                            Idcliente = (int)dr["idcliente"],
                            Tipodocumentoidentidad = new clsTipoDocumentoIdentidad()
                            {
                                Idtipodocumentoidentidad = (int)dr["idtipodocumentoidentidad"],
                                Descripcion = (string)dr["descripcion"],
                                Codsunat = (string)dr["codsunat"]
                            },

                            Nombreyapellido = (string)dr["nombreyapellido"],
                            Documento = (string)dr["documento"],
                            Direccion = (string)dr["direccion"]
                        };
                    }
                }
                return cli;
            }
            catch (MySqlException ex)
            {
                return cli;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable listar_cliente()
        {
            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_cliente", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public clsCliente listar_cliente_xnumeroplaca(clsPlaca placa)
        {
            clsCliente cli = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("listar_cliente_xnumeroplaca", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_numero", MySqlDbType.VarChar));
                cmd.Parameters[0].Value = placa.Numero;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cli = new clsCliente()
                        {

                            Idcliente = (int)dr["idcliente"],
                            Tipodocumentoidentidad = new clsTipoDocumentoIdentidad()
                            {
                                Idtipodocumentoidentidad = (int)dr["idtipodocumentoidentidad"],
                                Descripcion = (string)dr["descripcion"],
                                Codsunat = (string)dr["codsunat"]
                            },

                            Nombreyapellido = (string)dr["nombreyapellido"],
                            Documento = (string)dr["documento"],
                            Direccion = (string)dr["direccion"],
                            Lista_placa=new List<clsPlaca>() {
                                new clsPlaca() {
                                    Idplaca = (int)dr["idplaca"],
                                    Numero=(string)dr["numero"]
                                }
                            }

                        };
                    }
                }
                return cli;
            }
            catch (MySqlException ex)
            {
                return cli;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public int registrar_cliente(clsCliente cliente)
        {
            int id = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("registrar_cliente", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_idtipodocumentoidentidad", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_nombreyapellido", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_documento", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_direccion", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_estado", MySqlDbType.Int32));


                cmd.Parameters[0].Value = cliente.Tipodocumentoidentidad.Idtipodocumentoidentidad;
                cmd.Parameters[1].Value = cliente.Nombreyapellido;
                cmd.Parameters[2].Value = cliente.Documento;
                cmd.Parameters[3].Value = cliente.Direccion;
                cmd.Parameters[4].Value = cliente.Estado;           

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
    }
}
