using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Controllers
{
    [Route("especies")]
    public class EspecieController : ControllerBase
    {
        private IEspecieService _especieService;

        public EspecieController(IEspecieService especieService)
        {
            _especieService = especieService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Especie>>> Get()
        {
            return Ok(await _especieService.Get());

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Especie>> Get(int id)
        {
            return Ok(await _especieService.Get(id));

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Especie>> Post([FromBody] Especie model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _especieService.Add(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { mensagem = $"Não foi possivel inserir o novo registro.", detalhe = e.Message });
            }
        }
    }
}