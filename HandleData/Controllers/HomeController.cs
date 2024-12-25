using HandleData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HandleData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public HomeController(ILogger<HomeController> logger, HttpClient httpClient, IConfiguration configuration)
        {
            _logger = logger;
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:ApiBaseUrl"];
        }

        public async Task<IActionResult> Index(string trigger = null)
        {
            if(trigger == null)
            {
                return View();
            }
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl + "/gateway/user");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(jsonResponse))
                {
                    return View("Error");
                }

                var users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
                return View(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while calling API.");
                return View("Error");
            }
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
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
    }
}
