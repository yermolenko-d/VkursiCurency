using System;
using System.Threading.Tasks;
using VkursiCurrency.Models;
using VkursiCurrency.Services.Interfaces;

namespace VkursiCurrency.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IHtmlService _httpService;

        public CurrencyService(IHtmlService httpService)
        {
            _httpService = httpService;
        }

        public async Task<double> GetCourse(CurrencyInfoModel model)
        {
            if (model.UahAmount <= 0)
            {
                return 0;
            }
            var course = await _httpService.GetResult(model.CurrencyType);
            return Math.Round(CountAmout(course, model.UahAmount), 2);
            
        }
        
        private double CountAmout(double course, double uahAmount)
        {
            return uahAmount / course;
        }
    }
}