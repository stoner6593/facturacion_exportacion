﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Comun.Dto.Modelos
{
    public class PaymentTerms
    {
        public string PaymentMeansID { get; set; }
        public string PaymentPercent { get; set; }
        public decimal Amount { get; set; }

    }
}
