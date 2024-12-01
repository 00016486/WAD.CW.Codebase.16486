using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD.CW.Codebase._16486.Data;
using WAD.CW.Codebase._16486.Interfaces;
using WAD.CW.Codebase._16486.Repositories;

namespace WAD.CW.DAL
{
    public static class ServicesConfig
    {
        public static IServiceCollection ServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ReceptionSystemDatabase")));
            services.AddScoped<IVisitorRepository, VisitorRepository>();
            services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
