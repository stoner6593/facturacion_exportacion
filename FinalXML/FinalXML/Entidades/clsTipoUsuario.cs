using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    public class clsTipoUsuario
    {
        private int idtipousuario;
        private string descripcion;

        public int Idtipousuario
        {
            get
            {
                return idtipousuario;
            }

            set
            {
                idtipousuario = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
    }
}
