using SistemaDeAgendamentos.API.Core.Utils;

namespace SistemaDeAgendamentos.API.Dominio.Pessoa
{
    public interface IPessoaRepository
    {
        Task<Resultado<Dominio.Pessoa.Pessoa, Falha>> NovaPessoaAsync(Pessoa nova);
    }
}
