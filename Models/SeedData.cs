using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GPFCManagementSystem.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GPFCContext(
                serviceProvider.GetRequiredService<DbContextOptions<GPFCContext>>()))
            {
                // Check if any teams exist, if yes, the DB has been seeded
                if (context.Teams.Any())
                {
                    return;   // DB has been seeded
                }

                // Define teams with coaches
                var teams = new[]
                {
                    new Team { TeamName = "U10 Boys Team A", CoachName = "Michael Thompson", Division = "U10" },
                    new Team { TeamName = "U10 Boys Team B", CoachName = "Jason Rivera", Division = "U10" },
                    new Team { TeamName = "U10 Girls Team A", CoachName = "Sarah Parker", Division = "U10" },
                    new Team { TeamName = "U10 Girls Team B", CoachName = "Jessica Nguyen", Division = "U10" },
                    new Team { TeamName = "U12 Boys Team", CoachName = "Robert Lee", Division = "U12" },
                    new Team { TeamName = "U12 Girls Team", CoachName = "Linda Kim", Division = "U12" }
                };
                context.Teams.AddRange(teams);
                context.SaveChanges();

                // Define players for each team
                var players = new[]
                {
                    // U10 Boys Team A
                    new Player { Name = "Ethan Martinez", TeamId = teams[0].TeamId, Age = 8 },
                    new Player { Name = "Noah Smith", TeamId = teams[0].TeamId, Age = 9 },
                    new Player { Name = "Liam Johnson", TeamId = teams[0].TeamId, Age = 9 },
                    new Player { Name = "Lucas Williams", TeamId = teams[0].TeamId, Age = 8 },
                    new Player { Name = "Mason Brown", TeamId = teams[0].TeamId, Age = 9 },
                    new Player { Name = "Jacob Jones", TeamId = teams[0].TeamId, Age = 9 },
                    new Player { Name = "Michael Garcia", TeamId = teams[0].TeamId, Age = 8 },
                    new Player { Name = "Alexander Davis", TeamId = teams[0].TeamId, Age = 9 },
                    new Player { Name = "Daniel Rodriguez", TeamId = teams[0].TeamId, Age = 9 },
                    new Player { Name = "Benjamin Wilson", TeamId = teams[0].TeamId, Age = 8 },

                    // U10 Boys Team B
                    new Player { Name = "Oliver Lee", TeamId = teams[1].TeamId, Age = 9 },
                    new Player { Name = "Samuel Anderson", TeamId = teams[1].TeamId, Age = 8 },
                    new Player { Name = "James Thomas", TeamId = teams[1].TeamId, Age = 9 },
                    new Player { Name = "Henry Jackson", TeamId = teams[1].TeamId, Age = 9 },
                    new Player { Name = "Logan White", TeamId = teams[1].TeamId, Age = 8 },
                    new Player { Name = "Aiden Harris", TeamId = teams[1].TeamId, Age = 9 },
                    new Player { Name = "Gabriel Clark", TeamId = teams[1].TeamId, Age = 9 },
                    new Player { Name = "Jack Lewis", TeamId = teams[1].TeamId, Age = 8 },
                    new Player { Name = "Elijah Walker", TeamId = teams[1].TeamId, Age = 9 },
                    new Player { Name = "Carter Allen", TeamId = teams[1].TeamId, Age = 9 },

                    // U10 Girls Team A
                    new Player { Name = "Emma Johnson", TeamId = teams[2].TeamId, Age = 9 },
                    new Player { Name = "Olivia Martinez", TeamId = teams[2].TeamId, Age = 8 },
                    new Player { Name = "Ava Smith", TeamId = teams[2].TeamId, Age = 9 },
                    new Player { Name = "Sophia Brown", TeamId = teams[2].TeamId, Age = 9 },
                    new Player { Name = "Isabella Garcia", TeamId = teams[2].TeamId, Age = 8 },
                    new Player { Name = "Mia Anderson", TeamId = teams[2].TeamId, Age = 9 },
                    new Player { Name = "Charlotte Jones", TeamId = teams[2].TeamId, Age = 9 },
                    new Player { Name = "Amelia Taylor", TeamId = teams[2].TeamId, Age = 9 },
                    new Player { Name = "Harper Moore", TeamId = teams[2].TeamId, Age = 9 },
                    new Player { Name = "Ella Jackson", TeamId = teams[2].TeamId, Age = 9 },

                    // U10 Girls Team B
                    new Player { Name = "Evelyn Lee", TeamId = teams[3].TeamId, Age = 8 },
                    new Player { Name = "Abigail Wilson", TeamId = teams[3].TeamId, Age = 9 },
                    new Player { Name = "Emily Young", TeamId = teams[3].TeamId, Age = 9 },
                    new Player { Name = "Elizabeth Hernandez", TeamId = teams[3].TeamId, Age = 9 },
                    new Player { Name = "Mila King", TeamId = teams[3].TeamId, Age = 9 },
                    new Player { Name = "Ella Scott", TeamId = teams[3].TeamId, Age = 9 },
                    new Player { Name = "Avery Wright", TeamId = teams[3].TeamId, Age = 8 },
                    new Player { Name = "Sofia Lopez", TeamId = teams[3].TeamId, Age = 9 },
                    new Player { Name = "Camila Hill", TeamId = teams[3].TeamId, Age = 8 },
                    new Player { Name = "Aria Green", TeamId = teams[3].TeamId, Age = 8 },

                    // U12 Boys Team
                    new Player { Name = "Jacob Taylor", TeamId = teams[4].TeamId, Age = 10 },
                    new Player { Name = "Ethan Lee", TeamId = teams[4].TeamId, Age = 11 },
                    new Player { Name = "Logan Smith", TeamId = teams[4].TeamId, Age = 10 },
                    new Player { Name = "Lucas Brown", TeamId = teams[4].TeamId, Age = 11 },
                    new Player { Name = "Mason Davis", TeamId = teams[4].TeamId, Age = 10 },
                    new Player { Name = "Aiden Wilson", TeamId = teams[4].TeamId, Age = 11 },
                    new Player { Name = "Oliver Martin", TeamId = teams[4].TeamId, Age = 10 },
                    new Player { Name = "Carter Thompson", TeamId = teams[4].TeamId, Age = 11 },
                    new Player { Name = "Jayden White", TeamId = teams[4].TeamId, Age = 10 },
                    new Player { Name = "Dylan Garcia", TeamId = teams[4].TeamId, Age = 11 },
                    new Player { Name = "Leo Harris", TeamId = teams[4].TeamId, Age = 10 },
                    new Player { Name = "Owen Clark", TeamId = teams[4].TeamId, Age = 11 },

                    // U12 Girls Team
                    new Player { Name = "Sophia Moore", TeamId = teams[5].TeamId, Age = 10 },
                    new Player { Name = "Isabella Young", TeamId = teams[5].TeamId, Age = 11 },
                    new Player { Name = "Mia Hernandez", TeamId = teams[5].TeamId, Age = 10 },
                    new Player { Name = "Amelia Walker", TeamId = teams[5].TeamId, Age = 11 },
                    new Player { Name = "Harper Hall", TeamId = teams[5].TeamId, Age = 10 },
                    new Player { Name = "Evelyn Allen", TeamId = teams[5].TeamId, Age = 11 },
                    new Player { Name = "Ava Wright", TeamId = teams[5].TeamId, Age = 10 },
                    new Player { Name = "Abigail King", TeamId = teams[5].TeamId, Age = 11 },
                    new Player { Name = "Emily Scott", TeamId = teams[5].TeamId, Age = 10 },
                    new Player { Name = "Madison Green", TeamId = teams[5].TeamId, Age = 11 },
                    new Player { Name = "Charlotte Adams", TeamId = teams[5].TeamId, Age = 10 },
                    new Player { Name = "Scarlett Nelson", TeamId = teams[5].TeamId, Age = 11 }
                };
                context.Players.AddRange(players);
                context.SaveChanges();
            }
        }
    }
}