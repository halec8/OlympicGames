using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OlympicGames.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace OlympicGames.Controllers
{
    public class HomeController : Controller
    {
        private readonly CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(string activeGame = "all",
            string activeSport = "all")

        {

            var session = new OlympicSession(HttpContext.Session);
            session.SetActiveGame(activeGame);
            session.SetActiveSport(activeSport);

            int? count = session.GetMyCountryCount();
            if (count == null)
            {
                var cookies = new OlympicCookies(Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                List<Country> mycountries = new List<Country>();
                if (ids.Length > 0)
                    mycountries = context.Countries.Include(c => c.Game)
                        .Include(c => c.Sport)
                        .Where(c => ids.Contains(c.CountryId)).ToList();
                session.SetMyCountries(mycountries);
            }

            var model = new CountryListViewModel
                {
                    ActiveGame = activeGame,
                    ActiveSport = activeSport,
                    Games = context.Games.ToList(),
                    Sports = context.Sports.ToList()
                };

            IQueryable<Country> query = context.Countries;
            if (activeGame != "all")
                query = query.Where(c => c.Game.GameId.ToLower() == activeGame.ToLower());
            if (activeSport != "all")
                query = query.Where(
                    c => c.Sport.SportId.ToLower() == activeSport.ToLower());
            model.Countries = query.ToList();

            return View(model);
        }


        [HttpPost]
        public IActionResult Details(CountryViewModel model)
        {
            Utility.LogCountryClick(model.Country.CountryId);

            TempData["ActiveGame"] = model.ActiveGame;
            TempData["ActiveSport"] = model.ActiveSport;
            return RedirectToAction("Details", new {ID = model.Country.CountryId});
        }

        public IActionResult Details(string id)
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(c => c.Game)
                    .Include(c => c.Sport)
                    .FirstOrDefault(c => c.CountryId == id),
                // adding session state 3/8/2022
                ActiveSport = session.GetActiveSport(),
                ActiveGame = session.GetActiveGame()
                // ActiveSport = TempData?["ActiveSport"]?.ToString() ?? "all",
                // ActiveGame = TempData?["ActiveGame"]?.ToString() ?? "all"
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries
                .Include(c => c.Game)
                .Include(c => c.Sport)
                .Where(c => c.CountryId == model.Country.CountryId)
                .FirstOrDefault();

            var session = new OlympicSession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(model.Country);
            session.SetMyCountries(countries);

            var cookies = new OlympicCookies(Response.Cookies);
            cookies.SetMyCountryIds(countries);

            TempData["message"] = $"{model.Country.Name} added to your favorites";

            return RedirectToAction("Index", 
                new {
                    ActiveGame = session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport()
            });
        }
    }
}
