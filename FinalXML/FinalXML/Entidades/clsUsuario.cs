using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    public class clsUsuario
    {

        private int idusuario;
        private clsTipoUsuario tipousuario;
        private string nombre;
        private string cuenta;
        private string clave;

        public int Idusuario
        {
            get
            {
                return idusuario;
            }

            set
            {
                idusuario = value;
            }
        }

        public clsTipoUsuario Tipousuario
        {
            get
            {
                return tipousuario;
            }

            set
            {
                tipousuario = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Cuenta
        {
            get
            {
                return cuenta;
            }

            set
            {
                cuenta = value;
            }
        }

        public string Clave
        {
            get
            {
                return clave;
            }

            set
            {
                clave = value;
            }
        }
    }
}
