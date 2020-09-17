using FinalXML.Entidades;
using FinalXML.Interfaces;
using FinalXML.InterMySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Administradores
{
    class clsAdmRepositorio
    {
        private IRepositorio irepo = new MysqlRepositorio();

        public clsRepositorio listar_repositorio_xtscfm(clsRepositorio repositorio) {

            return irepo.listar_repositorio_xtscfm(repositorio);
        }

        public int registrar_repositorio(clsRepositorio repositorio) {

            return irepo.registrar_repositorio(repositorio);
        }

        public int actualizar_repositorio(clsRepositorio repositorio) {

            return irepo.actualizar_repositorio(repositorio);
        }

        public DataTable listar_repositorio_xtsfe(clsNumeracion numeracion) {

            return irepo.listar_repositorio_xtsfe(numeracion);
        }

        public clsRepositorio listar_archivo_xrepositorio(clsRepositorio repositorio) {

            return irepo.listar_archivo_xrepositorio(repositorio);
        }
    }
}
