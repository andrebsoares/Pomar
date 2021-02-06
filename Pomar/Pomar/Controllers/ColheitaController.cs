using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Controllers
{
    [Route("colheitas")]
    [Authorize]
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

        [HttpPut]
        [Route("{codigo:int}")]
        public async Task<ActionResult<Colheita>> Put([FromBody] Colheita model, int codigo)
        {
            if (codigo != model.Codigo)
                return BadRequest("Colheita não existe");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.Update(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { mensagem = "Não foi possível alterar colheita", detalhe = e.Message });
            }
        }

        [HttpDelete]
        [Route("{codigo:int}")]
        public async Task<ActionResult> Delete(int codigo)
        {
            try
            {
                await _service.Remove(codigo);
                return null;
            }
            catch (Exception e)
            {
                return BadRequest(new { mensagem = "Nã foi possível excluir colheita", detalhe = e.InnerException.Message });
            }
        }
    }
}