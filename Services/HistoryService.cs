using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkursiCurrency.Data;
using VkursiCurrency.Models;
using VkursiCurrency.Services.Interfaces;

namespace VkursiCurrency.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly ApplicationDbContext _context;

        public HistoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveToHistory(CurrencyInfoModel model, string username)
        {
            if (model.UahAmount <= 0)
            {
                return;
            }

            HistoryRecord record = new HistoryRecord()
            {
                CurrencyAmount = model.CurrencyAmount.ToString(),
                CurrencyType = model.CurrencyType,
                UahAmount = model.UahAmount.ToString(),
                User = username != null ? username : "anonymous"
            };
            _context.HistoryRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task<List<HistoryRecord>> GetHistory()
        {
            return await _context.HistoryRecords.ToListAsync();
        }
    }
}
