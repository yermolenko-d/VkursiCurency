using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkursiCurrency.Data;
using VkursiCurrency.Models;

namespace VkursiCurrency.Services.Interfaces
{
    public interface IHistoryService
    {
        Task SaveToHistory(CurrencyInfoModel model, string username);
        Task<List<HistoryRecord>> GetHistory();
    }
}
