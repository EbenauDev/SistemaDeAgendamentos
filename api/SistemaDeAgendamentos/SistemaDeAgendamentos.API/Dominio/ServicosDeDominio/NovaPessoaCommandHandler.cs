using SistemaDeAgendamentos.API.Aplicacao;
using SistemaDeAgendamentos.API.Core.Utils;
using SistemaDeAgendamentos.API.Dominio.Pessoa;

namespace SistemaDeAgendamentos.API.Dominio.ServicosDeDominio
{
    public interface INovaPessoaComandHandler
    {
        Task<Resultado<Pessoa.Pessoa, Falha>> ExecutarAsync(NovaPessoaCommand novaPessoaComand);
    }

    public class NovaPessoaCommandHandler : INovaPessoaComandHandler
    {
        private readonly IPessoaRepository _pessoaRepositorio;

        public NovaPessoaCommandHandler(IPessoaRepository pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public async Task<Resultado<Pessoa.Pessoa, Falha>> ExecutarAsync(NovaPessoaCommand novaPessoaComand)
        {
            var pessoa = Pessoa.Pessoa.NovaPessoa(
                novaPessoaComand.Nome,
                novaPessoaComand.Email,
                novaPessoaComand.Celular,
                novaPessoaComand.Cpf);

            if (await _pessoaRepositorio.NovaPessoaAsync(pessoa) is var resultado && resultado.EhFalha)
                return resultado.Falha;
            return resultado.Sucesso;
        }
    }
}
