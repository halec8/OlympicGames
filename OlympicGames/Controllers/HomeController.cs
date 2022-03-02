using Microsoft.AspNetCore.Mvc;
using OlympicGames.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OlympicGames.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(string activeGame = "all", 
                                   string activeSport = "all")

        {
            var data = new CountryListViewModel
            {
                ActiveGame = activeGame,
                ActiveSport = activeSport,
                Games = context.Games.ToList(),
                Sports = context.Sports.ToList()
            };

            IQueryable<Country> query = context.Countries;
            if (activeGame !="all")
                query = query.Where(c => c.Game.GameId.ToLower() == activeGame.ToLower());
            if (activeSport !="all")
                query = query.Where(
                    c => c.Sport.SportId.ToLower() == activeSport.ToLower());
            data.Countries = query.ToList();

            return View(data);
        }

        [HttpPost]
        public IActionResult Details(CountryViewModel model)
        {
            Utility.LogCountryClick(model.Country.CountryId);

            TempData["ActiveGame"] = model.ActiveGame;
            TempData["ActiveSport"] = model.ActiveSport;
            return RedirectToAction("Details", new {ID = model.Country.CountryId});
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(c => c.Game)
                    .Include(c => c.Sport)
                    .FirstOrDefault(c => c.CountryId == id),
                ActiveSport = TempData?["ActiveSport"]?.ToString() ?? "all",
                ActiveGame = TempData?["ActiveGame"]?.ToString() ?? "all"
            };
            return View(model);
        }
    }
}
