using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BeekeepersCorner.Data;

namespace BeekeepersCorner.Models
{
    public static class DbInitializer
    {

        public static void Initialize(BeekeepersDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any beekeepers, add if there are none in table.
            if (!context.Beekeepers.Any())
            {

                var beekeepers = new Beekeeper[]
                {
                new Beekeeper{FirstName="Lee",LastName="Mullen",Address="5822 Pioneer Rd S",City="Saint Paul Park",State="MN",Zipcode="55071",Phone="123-123-1234",Email="lee_mullen@hotmail.com"},
                new Beekeeper{FirstName="John",LastName="Doe",Address="Any St",City="Town",State="MN",Zipcode="55555",Phone="",Email=""}
                };

                foreach (Beekeeper b in beekeepers)
                {
                    context.Beekeepers.Add(b);
                }

                context.SaveChanges();
                
            }

            // Look for any beehives, add if there are none in table.
            if (!context.Beehives.Any())
            {

                var beehives = new Beehive[]
                {
                new Beehive{BeekeeperIDFK=1,HiveName="No 1",InstallDate=Convert.ToDateTime("2016-4-15"),Notes="Not a good hive.",HoneyProduction=25},
                new Beehive{BeekeeperIDFK=2,HiveName="Big Hive",InstallDate=Convert.ToDateTime("2016-4-15"),Notes="My best hive.",HoneyProduction=100}
                };

                foreach (Beehive b in beehives)
                {
                    context.Beehives.Add(b);
                }

                context.SaveChanges();

            }

            return;   // DB has been seeded

        }    
    }
}
