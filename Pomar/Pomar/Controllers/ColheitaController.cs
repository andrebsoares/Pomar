using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Controllers
{
    [Route("colheitas")]
    public class ColheitaController : ControllerBase
    {
        private IColheitaService _service;

        public ColheitaController(IColheitaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Colheita>>> Get()
        {
            return Ok(await _service.Get());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Colheita>> Get(int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Colheita>> Post([FromBody] Colheita model)
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
                return BadRequest(new { mensagem = $"Não foi possivel inserir o novo registro.", detalhe = e.Message });
            }
        }
    }
}