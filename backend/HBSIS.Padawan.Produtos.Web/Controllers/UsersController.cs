using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using HBSIS.Padawan.Produtos.Application.Services.Usuario;
using HBSIS.Padawan.Produtos.Domain.Entities;

namespace HBSIS.Padawan.Produtos.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UsuarioEntity userParam)
        {
            var user = await _userService.Authenticate(userParam.Usuario, userParam.Senha);

            if (user == null)
                return BadRequest(new { message = "Usuário ou senha estão incorretos." });

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
    }
}