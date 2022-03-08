using System.Collections.Generic;

namespace OlympicGames.Models
{
    public class CountryListViewModel : CountryViewModel
    {
        public List<Country> Countries { get; set; }

        private List<Game> games;

        public List<Game> Games
        {
            get => games;
            set
            {
                games = new List<Game>
                {
                    new Game {GameId = "all", Name = "All"}
                };
                games.AddRange(value);
            }
        }

        private List<Sport> sports;

         public List<Sport> Sports
         {
             get => sports;
             set
             {
                 sports = new List<Sport>
                 {
                     new Sport() {SportId = "all", Name = "All"}
                 };
                 sports.AddRange(value);
             }
         }


        public string CheckActiveGame(string g) =>
            g.ToLower() == ActiveGame.ToLower() ? "active" : "";

        public string CheckActiveSport(string s) =>
            s.ToLower() == ActiveSport.ToLower() ? "active" : "";
    }
}
