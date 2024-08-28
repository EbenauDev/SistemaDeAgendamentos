using Dapper;
using Microsoft.Data.SqlClient;
using SistemaDeAgendamentos.API.Core.Utils;
using SistemaDeAgendamentos.API.Dominio.Pessoa;

namespace SistemaDeAgendamentos.API.Infra.Pessoa
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly string _stringDeConexao;

        public PessoaRepositorio(IConfiguration configuration)
        {
            _stringDeConexao = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Resultado<Dominio.Pessoa.Pessoa, Falha>> NovaPessoaAsync(Dominio.Pessoa.Pessoa nova)
        {
            const string sql = @"INSERT INTO Pessoa(Nome, Email, Celular, CPF)
                                 VALUES(
	                                 @Nome,
	                                 @Email,
	                                 @Celular,
	                                 @Cpf
                                 )
                                 SELECT SCOPE_IDENTITY() AS IdPessoa";

            using (var conexao = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    await conexao.OpenAsync();
                    var resultado = await conexao.QueryFirstOrDefaultAsync<int>(sql, new
                    {
                        nova.Nome,
                        nova.Email,
                        nova.Celular,
                        nova.Cpf,
                    });
                    if (resultado < 0)
                        return Falha.Nova("Houve um problema ao realizar o cadastro da pessoa");

                    nova.DefinirIdentidade(resultado);
                    return nova;
                }
                catch (Exception ex)
                {
                    return Falha.Nova(ex.Message);
                }
                finally
                {
                    await conexao.CloseAsync();
                }
            }
        }
    }
}
