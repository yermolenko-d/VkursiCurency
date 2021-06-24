using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkursiCurrency.Data
{
    public class HistoryRecord
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string UahAmount { get; set; }
        public string CurrencyType { get; set; }
        public string CurrencyAmount { get; set; }
    }
}
