using SistemaDeAgendamentos.API.Dominio.Pessoa;
using SistemaDeAgendamentos.API.Dominio.ServicosDeDominio;
using SistemaDeAgendamentos.API.Infra.Pessoa;

namespace SistemaDeAgendamentos.API
{
    public static class ServiceDependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            services.AddScoped<INovaPessoaComandHandler, NovaPessoaComandHandler>();
            return services;
        }
    }
}
