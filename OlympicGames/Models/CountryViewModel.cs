namespace OlympicGames.Models
{
    public class CountryViewModel
    {
        public Country Country { get; set; }
        public string ActiveGame { get; set; } = "all";
        public string ActiveSport { get; set; } = "all";
    }
}
