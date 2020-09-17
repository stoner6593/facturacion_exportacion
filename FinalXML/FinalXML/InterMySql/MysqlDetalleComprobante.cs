using FinalXML.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Entidades;
using System.Data;
using MySql.Data.MySqlClient;
using FinalXML.Conexion;
using WinApp.Comun.Dto.Modelos;
namespace FinalXML.InterMySql
{
    class MysqlDetalleComprobante : IDetalleComprobante
    {

        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction tra = null;
        private DataTable tabla = null;


        public bool updatedetalle(DetalleDocumento Detalle)
        {
            throw new NotImplementedException();
        }

        public bool anuladetalle(int CodigoDetalle)
        {
            throw new NotImplementedException();
        }

        public bool insertdetalle(int idrepo, DetalleDocumento Detalle)
        {
            bool id = false;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("registro_detcomprobante", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_idrepositorio", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_nombreproducto", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_cantidad", MySqlDbType.Decimal));
                cmd.Parameters.Add(new MySqlParameter("@_unidadmedida", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_subtotal", MySqlDbType.Decimal));
                cmd.Parameters.Add(new MySqlParameter("@_igv", MySqlDbType.Decimal));
                cmd.Parameters.Add(new MySqlParameter("@_total", MySqlDbType.Decimal));
                cmd.Parameters.Add(new MySqlParameter("@_precio", MySqlDbType.Decimal));

                cmd.Parameters[0].Value = idrepo;
                cmd.Parameters[1].Value = Detalle.Descripcion;
                cmd.Parameters[2].Value = Detalle.Cantidad;
                cmd.Parameters[3].Value = Detalle.UnidadMedida;
                cmd.Parameters[4].Value = Detalle.SubTotalVenta;
                cmd.Parameters[5].Value = Detalle.Impuesto;
                cmd.Parameters[6].Value = Detalle.TotalVenta;
                cmd.Parameters[7].Value = Detalle.PrecioUnitario;

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        id = true;
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

        public DataTable listarxcomprobante(int idcomprobante)
        {

            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_detalle_idcomprobante", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_idcomprobante", MySqlDbType.Int32));

                cmd.Parameters[0].Value = idcomprobante;

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }
    }
}
