using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Superheroes.Data;
using Superheroes.Models;

namespace Superheroes.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _Context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _Context)
        {
            this._Context = _Context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            SuperHero hero = _Context.heroes.Where(h => h.favorite == true).Single();
            return View(hero);
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
