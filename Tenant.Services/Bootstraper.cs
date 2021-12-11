using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tenant.Repositories;
using Tenant.Services.Services;

namespace Tenant.Services
{
    public static class Bootstraper
    {
        public static void InitializeRepositories(IServiceCollection services, IConfiguration Configuration)
        {
           services.AddDbContext<TenantContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TenantConnection")));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
        }
        public static void InitializeServices(IServiceCollection services, IConfiguration Configuration)
        {
            InitializeRepositories(services, Configuration);
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IGenderService, GenderService>();
        }
      
    }
}
