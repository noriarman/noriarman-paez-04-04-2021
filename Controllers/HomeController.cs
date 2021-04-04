using BertoniTestNoriarmanMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BertoniTestNoriarmanMVC.Util;
using Newtonsoft.Json;

namespace BertoniTestNoriarmanMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestUtil _restUtil;

        public HomeController(ILogger<HomeController> logger, IRestUtil  restUtil)
        {
            _logger = logger;
            _restUtil = restUtil;
        }
        public async Task<IActionResult> Index()
        {
            var url = "https://s3.amazonaws.com/dolartoday/data.json";
            var response = await _restUtil.GetAsync(url).ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<DolarToday>(response.Content);
            return View(data);
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
