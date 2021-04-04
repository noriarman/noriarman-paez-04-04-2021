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
using System.Net;

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
            var url = "https://jsonplaceholder.typicode.com/albums";
            var response = await _restUtil.GetAsync(url).ConfigureAwait(false);
            List<Albums> data = JsonConvert.DeserializeObject<List<Albums>>(response.Content);
            return View(data);
        }

        public async Task<IActionResult> Photos(int? id)
        {
            var url = $"https://jsonplaceholder.typicode.com/photos?albumId={id}";
            var response = await _restUtil.GetAsync(url).ConfigureAwait(false);
            List<Photos> data = JsonConvert.DeserializeObject<List<Photos>>(response.Content);
            return View(data);
        }

        public async Task<IActionResult> Comments(int? id)
        {
            var url = $"https://jsonplaceholder.typicode.com/comments?postId={id}";
            var response = await _restUtil.GetAsync(url).ConfigureAwait(false);
            List<Comments> data = JsonConvert.DeserializeObject<List<Comments>>(response.Content);
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
