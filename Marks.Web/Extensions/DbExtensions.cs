using Marks.Database;
using Marks.Database.SeedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Marks.Web.Extensions
{
    public static class DbExtensions
    {
        /// <summary>
        /// Seeds data into database on startup.
        /// </summary>
        /// <param name="host">Web host object</param>
        /// <returns>Web host object</returns>
        public static IWebHost SeedData(this IWebHost host)
        {
            var serviceScopeFactory = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<AppDbContext>();

                dbContext.Database.Migrate();

                DataSeeder.SeedPeople(dbContext);
            }

            return host;
        }
    }
}
