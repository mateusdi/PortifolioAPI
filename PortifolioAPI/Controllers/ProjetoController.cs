using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.DTOs;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Interfaces;

namespace Portifolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjeto _projetoRepository;

        public ProjetoController(IProjeto genericRepository)
        {
            _projetoRepository = genericRepository ?? throw new ArgumentNullException(nameof(genericRepository));
        }

        [HttpGet(Name = "GetAllProjetos")]
        public async Task<ActionResult<List<Projeto>>> GetAll()
        {
            return await _projetoRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetById(int id)
        {
            return await _projetoRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Projeto>> Create(Projeto projeto)
        {
            _projetoRepository.Create(projeto);
            //existe uma convenção para retornar a referencia(location) da entidade criada
            return CreatedAtAction(nameof(GetById), new { projeto.id }, projeto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _projetoRepository.Delete(id);
            //retornar alguma coisa se for sucesso
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem()
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTodoItem()
        {
            return Ok();
        }
    }
}
