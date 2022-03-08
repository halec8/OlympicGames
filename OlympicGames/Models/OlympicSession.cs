using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace OlympicGames.Models
{
    public class OlympicSession
    {
        private const string CountryKey = "mycountry";
        private const string CountKey = "countrycount";
        private const string GameKey = "game";
        private const string SportKey = "sport";

        private ISession session { get; set; }

        public OlympicSession(ISession session)
        {
            this.session = session;
        }

        public void SetMyCountries(List<Country> countries)
        {
            session.SetObject(CountryKey, countries);
            session.SetInt32(CountKey, countries.Count);
        }

        public List<Country> GetMyCountries() =>
            session.GetObject<List<Country>>(CountryKey) ?? new List<Country>(); // error

        public int? GetMyCountryCount() => session.GetInt32(CountKey);

        public void SetActiveGame(string activeGame) =>
            session.SetString(GameKey, activeGame);

        public string GetActiveGame() => session.GetString(GameKey);

        public void SetActiveSport(string activeSport) =>
            session.SetString(SportKey, activeSport);
        public string GetActiveSport() => session.GetString(SportKey);

        public void RemoveMyCountries()
        {
            session.Remove(CountryKey);
            session.Remove(CountKey);

        }
    }
}
