using Microsoft.IdentityModel.Tokens;
using PlatformService.Model;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ApplicationDbContext>());
            }

        }
        private static void SeedData(ApplicationDbContext _db)
        {
            if (!_db.Platforms.Any())
            {
                Console.WriteLine("Seeding Data...");
                _db.Platforms.AddRange(
                    new Platform() { Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                    new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native", Cost = "Free" }
                    );
                _db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data");
            }
        }
    }
}
