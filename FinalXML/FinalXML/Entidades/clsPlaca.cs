using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    class clsPlaca
    {
        private int idplaca;
        private clsCliente cliente;
        private string numero;

        public int Idplaca
        {
            get
            {
                return idplaca;
            }

            set
            {
                idplaca = value;
            }
        }

        public clsCliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }
    }
}
