

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portifolio.Domain.Interfaces;
using Portifolio.Infra.Data.Context;
using Portifolio.Infra.Data.Repositories;

namespace Portifolio.Infra.Ioc
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(opt =>
            opt.UseInMemoryDatabase("portifolio"));

            services.AddScoped<IPessoa, PessoaRepository>();


            return services;
        }
    }
}
