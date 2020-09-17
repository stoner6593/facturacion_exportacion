using FinalXML.Conexion;
using FinalXML.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Administradores;
using FinalXML.Entidades;

namespace FinalXML.InterMySql
{
    class MysqlRepositorio : IRepositorio
    {
        private clsConexionMysql con = new clsConexionMysql();
        private MySqlCommand cmd = null;
        private MySqlDataReader dr = null;
        private MySqlDataAdapter adap = null;
        private MySqlTransaction tra = null;
        private DataTable tabla = null;

        public clsRepositorio listar_repositorio_xtscfm(clsRepositorio repositorio)
        {
            clsRepositorio repo = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("listar_repositorio_xtscfm", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_tipocomprobante", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_serie", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_correlativo", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_fechaemision", MySqlDbType.Date));
                cmd.Parameters.Add(new MySqlParameter("@_monto", MySqlDbType.Decimal));

                cmd.Parameters[0].Value = repositorio.Tipodocumento;
                cmd.Parameters[1].Value = repositorio.Serie;
                cmd.Parameters[2].Value = repositorio.Correlativo;
                cmd.Parameters[3].Value = repositorio.Fechaemision;
                cmd.Parameters[4].Value = repositorio.Monto;

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        repo = repositorio;
                        repo.Repositorioid = (int)dr["repositorioid"];

                    }
                }
                else {

                    repo = repositorio;
                    repo.Repositorioid = 0;
                }
                return repo;
            }
            catch (MySqlException ex)
            {
                return repo;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public int registrar_repositorio(clsRepositorio repositorio)
        {
            int id = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("registrar_repositorio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_tipocomprobante", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_serie", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_correlativo", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_comprobante", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_fechaemision", MySqlDbType.Date));
                cmd.Parameters.Add(new MySqlParameter("@_monto", MySqlDbType.Decimal));
                cmd.Parameters.Add(new MySqlParameter("@_estadosunat", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_mensajesunat", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_nombredocxml", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_rutaxml", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_nombredocpdf", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_rutapdf", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_pcorigen", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_usuariopc", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_docxml", MySqlDbType.LongBlob));
                cmd.Parameters.Add(new MySqlParameter("@_docpdf", MySqlDbType.LongBlob));
                cmd.Parameters.Add(new MySqlParameter("@_doczip", MySqlDbType.LongBlob));
                cmd.Parameters.Add(new MySqlParameter("@_cliente", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_documento_cliente", MySqlDbType.VarChar));

                cmd.Parameters[0].Value = repositorio.Tipodocumento;
                cmd.Parameters[1].Value = repositorio.Serie;
                cmd.Parameters[2].Value = repositorio.Correlativo;
                cmd.Parameters[3].Value = repositorio.Comprobante;
                cmd.Parameters[4].Value = repositorio.Fechaemision;
                cmd.Parameters[5].Value = repositorio.Monto;
                cmd.Parameters[6].Value = repositorio.Estadosunat;
                cmd.Parameters[7].Value = repositorio.Mensajesunat;
                cmd.Parameters[8].Value = repositorio.Nombredocxml;
                cmd.Parameters[9].Value = repositorio.Rutaxml;
                cmd.Parameters[10].Value = repositorio.Nombredocpdf;
                cmd.Parameters[11].Value = repositorio.Rutapdf;
                cmd.Parameters[12].Value = repositorio.Pcorigen;
                cmd.Parameters[13].Value = repositorio.Usuariopc;
                cmd.Parameters[14].Value = repositorio.Archivo.Xml;
                cmd.Parameters[15].Value = repositorio.Archivo.Pdf;
                cmd.Parameters[16].Value = repositorio.Archivo.Zip;
                cmd.Parameters[17].Value = repositorio.Cliente.Nombreyapellido;
                cmd.Parameters[18].Value = repositorio.Cliente.Documento;

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

        public int actualizar_repositorio(clsRepositorio repositorio)
        {
            int filas_afectadas = -1;

            try
            {
                con.conectarBD();
                tra = con.conector.BeginTransaction();
                cmd = new MySqlCommand("actualizar_repositorio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tra;
                cmd.Parameters.Add(new MySqlParameter("@_repositorioid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_estadosunat", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("@_mensajesunat", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_pcorigenactualiza", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_usuariopcactualiza", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_docxml", MySqlDbType.LongBlob));
                cmd.Parameters.Add(new MySqlParameter("@_docpdf", MySqlDbType.LongBlob));
                cmd.Parameters.Add(new MySqlParameter("@_doczip", MySqlDbType.LongBlob));

                cmd.Parameters[0].Value = repositorio.Repositorioid;
                cmd.Parameters[1].Value = repositorio.Estadosunat;
                cmd.Parameters[2].Value = repositorio.Mensajesunat;
                cmd.Parameters[3].Value = repositorio.Pcorigen;
                cmd.Parameters[4].Value = repositorio.Usuariopc;
                cmd.Parameters[5].Value = repositorio.Archivo.Xml;
                cmd.Parameters[6].Value = repositorio.Archivo.Pdf;
                cmd.Parameters[7].Value = repositorio.Archivo.Zip;

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

        public DataTable listar_repositorio_xtsfe(clsNumeracion numeracion)
        {

            tabla = new DataTable();

            using (con.conectarBD())
            {
                cmd = new MySqlCommand("listar_repositorio_xtsfe", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_tipocomprobante", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_serie", MySqlDbType.VarChar));
                cmd.Parameters.Add(new MySqlParameter("@_fechaemision", MySqlDbType.Date));
                cmd.Parameters.Add(new MySqlParameter("@_estadosunat", MySqlDbType.Int32));

                cmd.Parameters[0].Value = numeracion.TipoDocumento;
                cmd.Parameters[1].Value = numeracion.Serie;
                cmd.Parameters[2].Value = numeracion.Fecha;
                cmd.Parameters[3].Value = numeracion.Estado;

                adap = new MySqlDataAdapter(cmd);
                adap.Fill(tabla);
            }

            return tabla;
        }

        public clsRepositorio listar_archivo_xrepositorio(clsRepositorio repositorio)
        {           
            clsRepositorio repo = null;
            try
            {
                con.conectarBD();
                cmd = new MySqlCommand("listar_archivo_xrepositorio", con.conector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@_repositorioid", MySqlDbType.Int32));
                cmd.Parameters[0].Value = repositorio.Repositorioid;

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {                  

                    while (dr.Read())
                    {
                        repo = new clsRepositorio() {

                            Archivo = new clsArchivo() {

                                Xml = (byte[])dr["docxml"],
                                Pdf= (byte[])dr["docpdf"]
                            },

                        };
                    }
                }
                return repo;
            }
            catch (MySqlException ex)
            {
                return repo;
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
    }
}
