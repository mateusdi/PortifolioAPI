using Microsoft.AspNetCore.Mvc;
using PortifolioAPI.Domain.DTOs;
using PortifolioAPI.Domain.Interfaces;
using PortifolioAPI.Domain.Models;


namespace PortifolioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly IGenerica<Projeto> _genericRepository;

        public ProjetoController(IGenerica<Projeto> genericRepository)
        {
            _genericRepository = genericRepository ?? throw new ArgumentNullException(nameof(genericRepository));
        }

        [HttpGet(Name = "GetAllProjetos")]
        public async Task<ActionResult<List<Projeto>>> GetAll()
        {
            return await _genericRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetById(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaDTO>> Create(Projeto projeto)
        {
            _genericRepository.Create(projeto);
            //existe uma convenção para retornar a referencia(location) da entidade criada
            return CreatedAtAction(nameof(GetById), new { id = projeto.id }, projeto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _genericRepository.Delete(id);
            //retornar alguma coisa se for sucesso
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Projeto projeto)
        {
            _genericRepository.Update(projeto);
            //retornar alguma coisa se for sucesso
            return CreatedAtAction(nameof(GetById), new { id = projeto.id }, projeto);
        }
    }
}
