using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinApp.Estructuras.CommonBasicComponents;

namespace WinApp.Estructuras.CommonAggregateComponents
{
    public class PaymentMeans
    {
        public string PaymentMeansCode { get; set; } //Medio de pago
        public string ID { get; set; } //Num. Cuenta
        public List<PaymentTerms> PaymentTerms { get; set; }
        public PaymentMeans() {

            PaymentTerms = new List<PaymentTerms>();
        }

    }
}
