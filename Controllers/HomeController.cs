using HRVacancies.Models;
using HRVacancies.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRVacancies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJwtTokenGenerator _tokenService;
        private readonly IConfiguration _config;


        public HomeController(ILogger<HomeController> logger, IJwtTokenGenerator jwtTokenGenerator, IConfiguration config)
        {
            _logger = logger;
            _tokenService = jwtTokenGenerator;
            _config = config;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");

            if (token == null)
            {
                return RedirectToAction("login", "Auth");

            }

            else if (!_tokenService.IsTokenValid(_config["AppSettings:Key"].ToString(), _config["AppSettings:Issuer"].ToString(), token))
            {
                return RedirectToAction("login", "Auth");
            }
            else
                return View();
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