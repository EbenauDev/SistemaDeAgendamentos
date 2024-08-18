using SistemaDeAgendamentos.API.Core;
using SistemaDeAgendamentos.API.Dominio.Pessoa;

namespace SistemaDeAgendamentos.API.Infra.Pessoa
{
    public class PessoaRepositorio : IPessoaRepositorio
    {

        public Task<Resultado<Dominio.Pessoa.Pessoa, Falha>> NovaPessoaAsync(Dominio.Pessoa.Pessoa nova)
        {
            throw new NotImplementedException();
        }
    }
}
