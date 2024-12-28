using Microsoft.AspNetCore.Mvc;
using SistemaDeAgendamentos.API.Aplicacao;
using SistemaDeAgendamentos.API.Core.Utils;

namespace SistemaDeAgendamentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Autenticar([FromBody] AutenticacaoCommand command)
        {
            if (command.Email.Equals("teste@teste.com") && command.Senha.Equals("123456"))
            {
                return Ok(new
                {
                    Foto = "",
                    User = "João dos Testes",
                    AccessToken = "",
                });
            }
            return BadRequest(Falha.Nova("Usuário ou senha inválidos"));


        }
    }
}
