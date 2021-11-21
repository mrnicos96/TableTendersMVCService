using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using TableTendersMVCService.Models;

namespace TableTendersMVCService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory clientFactory;

        public HomeController(
            ILogger<HomeController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            clientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTender()
        {
            ViewData["Title"] = "Все строки табллицы полоченые от сервиса API";
            string uri = "api/tender";

            var client = clientFactory.CreateClient(
                name: "TableTendersAPIService");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get, requestUri: uri);

            HttpResponseMessage response = await client.SendAsync(request);

            string jsonString = await response.Content.ReadAsStringAsync();

            if (jsonString.Contains("[]"))
            {
                return View(null);
            }

            IEnumerable<Tender> model = JsonConvert
                .DeserializeObject<IEnumerable<Tender>>(jsonString);

            return View(model);
        }

        private readonly ILogger<HomeController> _logger;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
