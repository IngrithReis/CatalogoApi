using CatalogoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LoginDTO login)
        {
            var usuario = "fulano";
            var senha = "me_empreguem";

            if( login.Usuario == usuario && login.Senha == senha)
            {
                return Ok(new { token = "wwwmemepreguem"});
            }

            return BadRequest();
        }
    }
}
