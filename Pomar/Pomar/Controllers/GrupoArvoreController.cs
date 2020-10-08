using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Controllers
{
    [Route("grupoarvores")]
    public class GrupoArvoreController : ControllerBase
    {
        private IGrupoArvoreService _service;

        public GrupoArvoreController(IGrupoArvoreService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<GrupoArvore>>> Get()
        {
            return Ok(await _service.Get());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<GrupoArvore>> Get(int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<GrupoArvore>> Post([FromBody] GrupoArvore model)
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