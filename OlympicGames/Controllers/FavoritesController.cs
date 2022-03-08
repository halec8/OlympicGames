using Microsoft.AspNetCore.Mvc;
using OlympicGames.Models;

namespace OlympicGames.Controllers
{
    public class FavoritesController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountryListViewModel // error
            {
                ActiveGame = session.GetActiveGame(),
                ActiveSport = session.GetActiveSport(),
                Countries = session.GetMyCountries()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);

            session.RemoveMyCountries();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorite Countries cleared";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport()
                });
        }
    }
}