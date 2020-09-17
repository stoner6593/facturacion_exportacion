using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

using FinalXML.Entidades;
using FinalXML.Interfaces;
using FinalXML.Conexion;

namespace FinalXML.InterMySql
{
    public class MysqlNumeracion : INumeracion
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

     
        public clsNumeracion BuscaNumeracion(String TipoDocumento)
        {
            clsNumeracion ser = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscarNumeracion", con.conector);
                cmd.Parameters.AddWithValue("tipdoc", TipoDocumento);                
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ser = new clsNumeracion();
                        ser.IDDocumento = Convert.ToInt32(dr.GetDecimal(0));
                        ser.TipoDocumento = Convert.ToString(dr.GetString(1));
                        ser.NombreDocumento = Convert.ToString(dr.GetString(2));
                        ser.Serie = Convert.ToString(dr.GetString(3));
                        ser.Numeracion = Convert.ToInt32(dr.GetInt32(4));                       
                    }
                }
                return ser;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsNumeracion BuscaNumeracion2(Int32 IndexTipoDocumento)
        {
            clsNumeracion ser = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscarNumeracion2", con.conector);
                cmd.Parameters.AddWithValue("indextipdoc_ex", IndexTipoDocumento);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ser = new clsNumeracion();
                        ser.IDDocumento = Convert.ToInt32(dr.GetDecimal(0));
                        ser.TipoDocumento = Convert.ToString(dr.GetString(1));
                        ser.NombreDocumento = Convert.ToString(dr.GetString(2));
                        ser.Serie = Convert.ToString(dr.GetString(3));
                        ser.Numeracion = Convert.ToInt32(dr.GetInt32(4));
                    }
                }
                return ser;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public clsNumeracion BuscaNumeracionDocBaja(String TipoDocumento)
        {
            clsNumeracion ser = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscarNumeracion", con.conector);
                cmd.Parameters.AddWithValue("tipdoc", TipoDocumento);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ser = new clsNumeracion();
                        ser.IDDocumento = Convert.ToInt32(dr.GetDecimal(0));
                        ser.TipoDocumento = Convert.ToString(dr.GetString(1));
                        ser.NombreDocumento = Convert.ToString(dr.GetString(2));
                        ser.Serie = Convert.ToString(dr.GetString(3));
                        ser.Numeracion = Convert.ToInt32(dr.GetInt32(4));
                    }
                }
                return ser;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public clsNumeracion BuscaNumeracionFac()
        {
            clsNumeracion ser = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("BuscaNumeracionFac", con.conector);              
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ser = new clsNumeracion();
                        ser.IDDocumento = Convert.ToInt32(dr.GetDecimal(0));
                        ser.TipoDocumento = Convert.ToString(dr.GetString(1));
                        ser.NombreDocumento = Convert.ToString(dr.GetString(2));
                        ser.Serie = Convert.ToString(dr.GetString(3));
                        ser.Numeracion = Convert.ToInt32(dr.GetInt32(4));
                    }
                }
                return ser;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public Boolean ActualizaNumeracion(clsNumeracion Numeracion)
        {
            try
            {
                con.conectarBD();

                cmd = new MySqlCommand("ActualizaNumeracion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tipdoc", Numeracion.TipoDocumento);
                cmd.Parameters.AddWithValue("seriec", Numeracion.Serie); 

                int x = cmd.ExecuteNonQuery();
                if (x != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable Listar()
        {

            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listanumeracion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public List<clsNumeracion> listar_Numeracion()
        {
            List<clsNumeracion> lista_numeracion = null;
            clsNumeracion ser = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("listar_numeracion", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    lista_numeracion = new List<clsNumeracion>();

                    while (dr.Read())
                    {
                        ser = new clsNumeracion();
                        ser.IDDocumento = Convert.ToInt32(dr.GetDecimal(0));
                        ser.TipoDocumento = Convert.ToString(dr.GetString(1));
                        ser.NombreDocumento = Convert.ToString(dr.GetString(2));
                        ser.Serie = Convert.ToString(dr.GetString(3));
                        ser.Numeracion = Convert.ToInt32(dr.GetInt32(4));
                        lista_numeracion.Add(ser);
                    }
                }
                return lista_numeracion;
            }
            catch (MySqlException ex)
            {
                return lista_numeracion;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

    }
}
