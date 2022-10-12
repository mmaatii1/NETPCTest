using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NETPCTest.Infrastructure.Data;

namespace NETPCTest.Infrastructure
{
    public static class StartupSetup 
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContactContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ContactsConnectionString"),
                    b => b.MigrationsAssembly(typeof(ContactContext).Assembly.FullName)));
        }
    }
}
