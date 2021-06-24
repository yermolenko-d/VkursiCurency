using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VkursiCurrency.Models;
using VkursiCurrency.Services.Interfaces;

namespace VkursiCurrency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyService _currencyService;
        private readonly IHistoryService _historyService;
        public HomeController(ICurrencyService currencyService, IHistoryService historyService)
        {
            _currencyService = currencyService;
            _historyService = historyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CountCurrency(CurrencyInfoModel model)
        {
            model.CurrencyAmount = await _currencyService.GetCourse(model);
            await _historyService.SaveToHistory(model, User.Identity.Name);
            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
