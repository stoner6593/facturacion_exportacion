﻿using System;

namespace WinApp.Estructuras.CommonBasicComponents
{
    [Serializable]
    public class PayableAmount
    {
        public string CurrencyId { get; set; }

        public decimal Value { get; set; }
        public decimal MultiplierFactorNumeric { get; set; }
    }
}
