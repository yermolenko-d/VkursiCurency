using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkursiCurrency.Services;
using VkursiCurrency.Services.Interfaces;

namespace VkursiCurrency.Extensions
{
    public static class Extensions
    {
        public static void RegisterCustomServices(this IServiceCollection serices, IConfiguration configuration)
        {
            serices.AddScoped<IHtmlService, HtmlService>();
            serices.AddScoped<ICurrencyService, CurrencyService>();
            serices.AddScoped<IHistoryService, HistoryService>();
        }
    }
}
