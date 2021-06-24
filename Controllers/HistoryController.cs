using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkursiCurrency.Services.Interfaces;

namespace VkursiCurrency.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _historyService.GetHistory());
        }
    }
}
