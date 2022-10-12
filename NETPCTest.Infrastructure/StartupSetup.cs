using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NETPCTest.Infrastructure.Data;
using NETPCTest.Core.Interfaces;
using NETPCTest.Infrastructure.DataAccess;
using NETPCTest.Infrastructure.Middleware;
using MediatR;
using NETPCTest.Application;
using NETPCTest.Core.Pipeline;

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
           
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));
            services.AddAutoMapper(typeof(ApplicationMappingProfile).Assembly);
            services.AddMediatR(typeof(ApplicationMappingProfile).Assembly);
        }
    }
}
