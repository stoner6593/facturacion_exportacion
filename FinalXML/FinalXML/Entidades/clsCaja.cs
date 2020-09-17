using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    public class clsCaja
    {
        private int cajaid;
        private clsUsuario usuario;
        private DateTime fechaapertura;
        private decimal montoapertura;
        private DateTime fechacierre;
        private decimal montocierre;
        private decimal totalefectivo;
        private decimal totaldeposito;
        private decimal totaltransferencia;
        private decimal totaltarjeta;
        private decimal totalnotacredito;
        private decimal totaldisponible;
        private int estado;

        public int Cajaid
        {
            get
            {
                return cajaid;
            }

            set
            {
                cajaid = value;
            }
        }

        public clsUsuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public DateTime Fechaapertura
        {
            get
            {
                return fechaapertura;
            }

            set
            {
                fechaapertura = value;
            }
        }

        public decimal Montoapertura
        {
            get
            {
                return montoapertura;
            }

            set
            {
                montoapertura = value;
            }
        }

        public DateTime Fechacierre
        {
            get
            {
                return fechacierre;
            }

            set
            {
                fechacierre = value;
            }
        }

        public decimal Montocierre
        {
            get
            {
                return montocierre;
            }

            set
            {
                montocierre = value;
            }
        }

        public decimal Totalefectivo
        {
            get
            {
                return totalefectivo;
            }

            set
            {
                totalefectivo = value;
            }
        }

        public decimal Totaldeposito
        {
            get
            {
                return totaldeposito;
            }

            set
            {
                totaldeposito = value;
            }
        }

        public decimal Totaltransferencia
        {
            get
            {
                return totaltransferencia;
            }

            set
            {
                totaltransferencia = value;
            }
        }

        public decimal Totaltarjeta
        {
            get
            {
                return totaltarjeta;
            }

            set
            {
                totaltarjeta = value;
            }
        }

        public decimal Totalnotacredito
        {
            get
            {
                return totalnotacredito;
            }

            set
            {
                totalnotacredito = value;
            }
        }

        public decimal Totaldisponible
        {
            get
            {
                return totaldisponible;
            }

            set
            {
                totaldisponible = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}
