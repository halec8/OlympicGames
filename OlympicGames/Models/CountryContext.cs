using Microsoft.EntityFrameworkCore;

namespace OlympicGames.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options)
        {}

        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Sport>Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().HasData(
                new Game {GameId = "wo", Name = "Winter Olympics"},
                new Game {GameId = "so", Name = "Summer Olympics"},
                new Game {GameId = "pa", Name = "Paralympics"},
                new Game {GameId = "yo", Name = "Youth Olympics"}
            );

            modelBuilder.Entity<Sport>().HasData(
                new Sport {SportId = "curl", Name = "Curling"},
                new Sport {SportId = "bob", Name = "Bobsleigh"},
                new Sport {SportId = "dive", Name = "Diving"},
                new Sport {SportId = "rc", Name = "Road Cycling"},
                new Sport {SportId = "arch", Name = "Archery"},
                new Sport{SportId = "cs", Name = "Canoe Spring"},
                new Sport{SportId = "bd", Name = "Break Dancing"},
                new Sport{SportId = "sb", Name = "Skateboarding"}
            );

            modelBuilder.Entity<Country>().HasData(
                new {CountryId = "ca", Name = "Canada", GameId = "wo", SportId= "curl", FlagImage = "ca.png"},
                new { CountryId = "se", Name = "Sweden", GameId = "wo", SportId = "curl", FlagImage = "se.png"},
                new { CountryId = "gb", Name = "Great Britain", GameId = "wo", SportId = "curl", FlagImage = "gb.png"},
                new { CountryId = "jm", Name = "Jamaica", GameId = "wo", SportId = "bob", FlagImage = "jm.png"},
                new { CountryId = "it", Name = "Italy", GameId = "wo", SportId = "bob", FlagImage= "it.png"},
                new { CountryId = "jp", Name = "Japan", GameId = "wo", SportId = "bob", FlagImage="jp.png" },
                new { CountryId = "germany", Name = "Germany", GameId = "so", SportId = "dive", FlagImage="germany.png"},
                new { CountryId = "china", Name = "China", GameId = "so", SportId = "dive", FlagImage="china.png"},
                new { CountryId = "mx", Name = "Mexico", GameId = "so", SportId = "dive", FlagImage="mx.png"},
                new { CountryId = "br", Name = "Brazil", GameId = "so", SportId = "rc", FlagImage="br.png"},
                new { CountryId = "bl", Name = "Netherlands", GameId = "so", SportId = "rc", FlagImage="nl.png"},
                new { CountryId = "us", Name = "USA", GameId = "so", SportId = "rc", FlagImage="us.png"},
                new { CountryId = "th", Name = "Thailand", GameId = "pa", SportId = "arch", FlagImage="th.png"},
                new { CountryId = "uy", Name = "Uruguay", GameId = "pa", SportId = "arch", FlagImage="uy.png"},
                new { CountryId = "ua", Name = "Ukraine", GameId = "pa", SportId = "arch", FlagImage="ua.png"},
                new { CountryId = "austria", Name = "Austria", GameId = "pa", SportId = "cs", FlagImage="austria.png"},
                new { CountryId = "pk", Name = "Pakistan", GameId = "pa", SportId = "cs", FlagImage ="pk.png"},
                new { CountryId = "zw", Name = "Zimbabwe", GameId = "pa", SportId = "cs", FlagImage ="zw.png" },
                new { CountryId = "fr", Name = "France", GameId = "yo", SportId = "bd", FlagImage ="fr.png" },
                new { CountryId = "cy", Name = "Cyprus", GameId = "yo", SportId = "bd", FlagImage = "cy.png" },
                new { CountryId = "ru", Name = "Russia", GameId = "yo", SportId = "bd", FlagImage = "ru.png" },
                new { CountryId = "fi", Name = "Finland", GameId = "yo", SportId = "sb", FlagImage = "fi.png" },
                new { CountryId = "sk", Name = "Slovakia", GameId = "yo", SportId = "sb", FlagImage = "sk.png" },
                new { CountryId = "pt", Name = "Portugal", GameId = "yo", SportId = "sb", FlagImage = "pt.png" }
    
            );
        }

    }




}
