using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeAgendamentos.API.Aplicacao;
using SistemaDeAgendamentos.API.Dominio.Pessoa;
using SistemaDeAgendamentos.API.Dominio.ServicosDeDominio;

namespace SistemaDeAgendamentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Nova(
            [FromServices] INovaPessoaComandHandler handler,
            [FromBody] NovaPessoaComand comand)
        {
            if (await handler.ExecutarAsync(comand) is var resultado && resultado.EhFalha)
                return BadRequest(resultado.Falha);
            return Ok(resultado.Sucesso);
        }
    }
}
