using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pomar.Interfaces.Services;
using Pomar.Models;
using Pomar.Service;

namespace Pomar.Controllers
{
    public class LoginController : ControllerBase
    {
        private IUserService _service;
        public LoginController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = await _service.Get(model.Usuario, model.Senha);

            if (user == null || user.Usuario != model.Usuario)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var hash = new HashService(SHA512.Create());

            string token = "Usuário ou senha inválidos";
            if (hash.CheckPassword(model.Senha, user.Senha))
                token = TokenService.GenerateToken(user);

            return new Login(
                usuario: model.Usuario,
                token: token
            );
        }
    }
}