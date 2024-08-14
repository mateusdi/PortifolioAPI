using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.DTOs;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Interfaces;
using Portifolio.Infra.Data.Repositories;

namespace Portifolio.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("Projetos")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjeto _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetoController(IProjeto genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _projetoRepository = genericRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Projeto>>> GetAll()
        {
            var projetos = await _projetoRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProjetoListDTO>>(projetos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetProjetoById(int id)
        {
            var projeto = await _projetoRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<ProjetoListDTO>(projeto));
        }

        [HttpPost]
        public async Task<ActionResult<Projeto>> Create(ProjetoDTO projetoDto)
        {
            var projeto = await _projetoRepository.Create(_mapper.Map<Projeto>(projetoDto));
            return CreatedAtAction(nameof(GetProjetoById), new { projeto.id }, _mapper.Map<ProjetoListDTO>(projeto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             await _projetoRepository.Delete(id);
            //retornar alguma coisa se for sucesso
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjeto(int id, ProjetoDTO projetoDto)
        {
            //atualiza a entidade toda
            await _projetoRepository.Update(id, _mapper.Map<Projeto>(projetoDto));
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProjeto(int id, [FromBody] JsonPatchDocument<Projeto> patchDoc)
        {
            //atualiza parcialmente a entidade
            var projeto = await _projetoRepository.GetByIdAsync(id);

            patchDoc.ApplyTo(projeto, ModelState);

            await _projetoRepository.Update(id, projeto);
            return Ok();
        }
    }
}
