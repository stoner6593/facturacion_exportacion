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
    public class MysqlProducto:IProducto
    {
        clsConexionMysql con = new clsConexionMysql();
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        MySqlDataAdapter adap = null;
        DataTable tabla = null;

        public clsProducto Insertar(clsProducto oProducto)
        {

            using (con.conectarBD())
            {

                cmd = new MySqlCommand("guardaproducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;

                oParam=cmd.Parameters.AddWithValue("refe", oProducto.Referencia);
                oParam=cmd.Parameters.AddWithValue("desp", oProducto.Descripcion);
                oParam=cmd.Parameters.AddWithValue("prec", oProducto.Precio);
                oParam=cmd.Parameters.AddWithValue("newid", 0);
                oParam.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

               oProducto.IdProducto = Convert.ToInt32(cmd.Parameters["newid"].Value);

            }

            return oProducto;

        }

        public clsProducto Buscar(Int32 codigo)
        {
            clsProducto oProducto = null;

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("buscarproducto", con.conector);
                cmd.Parameters.AddWithValue("codprod", codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        oProducto = new clsProducto();
                        oProducto.IdProducto = dr.GetInt32(0);
                        oProducto.Referencia = dr.GetString(1);
                        oProducto.Descripcion =dr.GetString(2);
                        oProducto.Precio = dr.GetDecimal(3);
                        
                    }
                }
            }
                return oProducto;
          }

        public DataTable Listar()
        {
          
            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listaproductos", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public DataTable Listar_xnombre(clsProducto producto)
        {

            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listaproductos_xnombre", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;
                oParam = cmd.Parameters.AddWithValue("_nombre", producto.Descripcion);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public DataTable Busqueda(string descripcion)
        {

            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("busquedaproducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;

                oParam = cmd.Parameters.AddWithValue("des", descripcion);
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public void Eliminar(Int32 codigo)
        {

            using (con.conectarBD())
            {

                cmd = new MySqlCommand("eliminaproducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;

                oParam = cmd.Parameters.AddWithValue("codprod", codigo);
               
                cmd.ExecuteNonQuery();


            }

        }

        public clsProducto Actualizar(clsProducto oProducto)
        {

            using (con.conectarBD())
            {

                cmd = new MySqlCommand("actualizaproducto", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter oParam;

                oParam = cmd.Parameters.AddWithValue("codpro", oProducto.IdProducto);
                oParam = cmd.Parameters.AddWithValue("refe", oProducto.Referencia);
                oParam = cmd.Parameters.AddWithValue("desp", oProducto.Descripcion);
                oParam = cmd.Parameters.AddWithValue("prec", oProducto.Precio);
          
                cmd.ExecuteNonQuery();


            }

            return oProducto;

        }
    }
 }


