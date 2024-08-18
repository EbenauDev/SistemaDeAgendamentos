using SistemaDeAgendamentos.API.Core;

namespace SistemaDeAgendamentos.API.Dominio.Pessoa
{
    public interface IPessoaRepositorio
    {
        Task<Resultado<Pessoa, Falha>> NovaPessoaAsync(Pessoa nova);
    }
}
