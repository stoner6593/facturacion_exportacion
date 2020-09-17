using FinalXML.Administradores;
using FinalXML.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Interfaces
{
    interface IRepositorio
    {
        clsRepositorio listar_repositorio_xtscfm(clsRepositorio repositorio);
        int registrar_repositorio(clsRepositorio repositorio);
        int actualizar_repositorio(clsRepositorio repositorio);
        DataTable listar_repositorio_xtsfe(clsNumeracion numeracion);
        clsRepositorio listar_archivo_xrepositorio(clsRepositorio repositorio);
    }
}
