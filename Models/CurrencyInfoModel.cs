using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VkursiCurrency.Models
{
    public class CurrencyInfoModel
    {
        public int UahAmount { get; set; }
        public string CurrencyType { get; set; }
        public double CurrencyAmount { get; set; }
    }
}
