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
    class MysqlUsuario:IUsuario 
    {
        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction tra = null;
        private DataTable tabla = null;

        public int registrar_usuario(clsUsuario usuario)
        {
            int id = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("registrar_usuario", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_idtipousuario", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_nombre", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_cuenta", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_clave", MySqlDbType.VarChar));               

                cmd.Parameters[0].Value = usuario.Tipousuario.Idtipousuario;
                cmd.Parameters[1].Value = usuario.Nombre;
                cmd.Parameters[2].Value = usuario.Cuenta;
                cmd.Parameters[3].Value = usuario.Clave;             

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
                tra.Rollback();
                return id;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public int actualizar_usuario(clsUsuario usuario)
        {
            int filas_afectadas = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("actualizar_usuario", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;

                cmd.Parameters.Add(new MySqlParameter("@_idusuario", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_idtipousuario", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_nombre", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_cuenta", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_clave", MySqlDbType.VarChar));

                cmd.Parameters[0].Value = usuario.Idusuario;
                cmd.Parameters[1].Value = usuario.Tipousuario.Idtipousuario;
                cmd.Parameters[2].Value = usuario.Nombre;
                cmd.Parameters[3].Value = usuario.Cuenta;
                cmd.Parameters[4].Value = usuario.Clave;

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

        public DataTable listar_usuario()
        {
            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_usuario", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;              
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public clsUsuario validar_usuario(clsUsuario usuario)
        {
            clsUsuario usu = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("validar_usuario", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_cuenta", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_clave", MySqlDbType.VarChar));
                cmd.Parameters[0].Value = usuario.Cuenta;
                cmd.Parameters[1].Value = usuario.Clave;

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        usu = new clsUsuario()
                        {
                            Idusuario=(int)dr["idusuario"],
                            Tipousuario=new clsTipoUsuario() {

                                Idtipousuario=(int)dr["idtipousuario"],
                                Descripcion=(string)dr["descripcion"],

                            },
                            Nombre=(string)dr["nombre"],
                            Cuenta=(string)dr["cuenta"],
                            Clave=(string)dr["clave"]
                        };
                    }
                }
                return usu;
            }
            catch (MySqlException ex)
            {
                return usu;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
