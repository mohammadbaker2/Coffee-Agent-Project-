using Microsoft.EntityFrameworkCore;

namespace Web_project.Models
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options)
            : base(options)
        {
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Cities
            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, Name = "Jenin" },
                new City { CityId = 2, Name = "Nablus" },
                new City { CityId = 3, Name = "Ramallah" },
                new City { CityId = 4, Name = "Jerusalem" }
            );

            // Seed Agents
            modelBuilder.Entity<Agent>().HasData(
                new Agent
                {
                    AgentId = 1,
                    Name = "Ahmad",
                    Salary = 3000,
                    Password = "123",
                    PhoneNumber = "0599000001",
                    CityId = 1
                },
                new Agent
                {
                    AgentId = 2,
                    Name = "Sara",
                    Salary = 3500,
                    Password = "456",
                    PhoneNumber = "0599000002",
                    CityId = 2
                }
            );
        }
    }
}