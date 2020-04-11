using HBSIS.Padawan.Produtos.Application.Services.Fornecedor;
using HBSIS.Padawan.Produtos.Domain.Interfaces;
using HBSIS.Padawan.Produtos.Infra.Repository.FornecedorRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBSIS.Padawan.Produtos.Web.DependencyInjection
{
    public static class SetupDependencies
    {
        public static void SetupServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFornecedorService, FornecedorService>();
        }

        public static void SetupRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        }
    }
}