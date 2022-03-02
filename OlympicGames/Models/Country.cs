namespace OlympicGames.Models
{
    public class Country
    {
        public string CountryId { get; set; }
        public string Name { get; set; }
        public string FlagImage { get; set; }
        public Sport Sport { get; set; }
        public Game Game { get; set; }
        
    }
}
