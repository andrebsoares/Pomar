using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Controllers
{
    [Route("arvores")]
    [Authorize]
    public class ArvoreController : ControllerBase
    {
        private IArvoreService _arvoreService;

        public ArvoreController(IArvoreService arvoreService)
        {
            _arvoreService = arvoreService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Arvore>>> Get()
        {
            return Ok(await _arvoreService.Get());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Arvore>> Get(int id)
        {
            return Ok(await _arvoreService.Get(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Arvore>> Post([FromBody] Arvore model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _arvoreService.Add(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { mensagem = $"Não foi possivel inserir o novo registro.", detalhe = e.Message });
            }
        }

        [HttpPut]
        [Route("{codigo:int}")]
        public async Task<ActionResult<Arvore>> Put([FromBody] Arvore model, int codigo)
        {
            if (codigo != model.Codigo)
                return NotFound(new { message = "Arvore não encontrada" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _arvoreService.Update(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { mensagem = "Não foi possível alterar o novo registro.", detalhe = e.Message });
            }
        }

        [HttpDelete]
        [Route("{codigo:int}")]
        public async Task<ActionResult> Delete(int codigo)
        {
            try
            {
                await _arvoreService.Remove(codigo);
                return null;
            }
            catch (Exception e)
            {
                return BadRequest(new { mensagem = "Não foi possível deletar a árvore", detalhe = e.InnerException.Message });
            }
        }
    }
}