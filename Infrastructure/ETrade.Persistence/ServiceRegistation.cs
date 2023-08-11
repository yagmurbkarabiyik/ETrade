using Microsoft.EntityFrameworkCore;
using ETrade.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ETrade.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("PostgreSQL");

            services.AddDbContext<ETradeDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}