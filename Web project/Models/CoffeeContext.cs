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
                    Salary = 4000,
                    Password = "123",
                    PhoneNumber = "0599004201",
                    CityId = 1,
                    Role = "Admin"
                },
                new Agent
                {
                    AgentId = 2,
                    Name = "Sara",
                    Salary = 3500,
                    Password = "456",
                    PhoneNumber = "0599540002",
                    CityId = 2,
                    Role = "User"
                },
                 new Agent
                 {
                     AgentId = 3,
                     Name = "Mohammad",
                     Salary = 3500,
                     Password = "453",
                     PhoneNumber = "0599005502",
                     CityId = 2,
                     Role = "User"
                 },
                  new Agent
                  {
                      AgentId = 4,
                      Name = "Dania",
                      Salary = 3530,
                      Password = "436",
                      PhoneNumber = "0599044002",
                      CityId = 1,
                      Role = "User"
                  },
                   new Agent
                   {
                       AgentId = 5,
                       Name = "Sami",
                       Salary = 3500,
                       Password = "156",
                       PhoneNumber = "0599034002",
                       CityId = 2,
                       Role = "User"
                   },
                    new Agent
                    {
                        AgentId = 6,
                        Name = "Ameed",
                        Salary = 3500,
                        Password = "236",
                        PhoneNumber = "0599004302",
                        CityId = 4,
                        Role = "User"
                    }


            );
        }
    }
}
