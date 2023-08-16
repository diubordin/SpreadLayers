using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpreadLayers.Application.Interfaces;
using SpreadLayers.Application.Mapping;
using SpreadLayers.Application.Services;
using SpreadLayers.Domain.Interfaces;
using SpreadLayers.Infra.Data.Context;
using SpreadLayers.Infra.Data.Identity;
using SpreadLayers.Infra.Data.Repositories;

namespace SpreadLayers.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
       ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //repos
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            //services
            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //var myhandlers = AppDomain.CurrentDomain.Load("SpreadLayers.Application");
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

            return services;
        }
    }
}