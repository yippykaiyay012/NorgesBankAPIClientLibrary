using System;
using System.Collections.Generic;
using System.Text;

namespace NorgesBankAPIClientLibrary
{
    public class CurrencyValue
    {
        public CurrencyTypes Currency { get; set; }
        public decimal Value { get; set; }
        public string Multiplier { get; set; }
    }
}
