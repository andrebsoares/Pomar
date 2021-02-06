using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Controllers
{
    [Route("users")]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<User>> Get()
        {
            return Ok(await _service.Get());
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post([FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.Add(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Não foi possível inserir o registro.", detalhe = e.InnerException.Message });
            }
        }
    }
}