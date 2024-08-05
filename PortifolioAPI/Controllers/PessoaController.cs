using Microsoft.AspNetCore.Mvc;

using PortifolioAPI.Interfaces;

using PortifolioAPI.Models;


namespace PortifolioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IGenerica<Pessoa> _genericRepository;

        public PessoaController(IGenerica<Pessoa> genericRepository)
        {
            _genericRepository = genericRepository ?? throw new ArgumentNullException(nameof(genericRepository));
        }

        [HttpGet(Name = "GetAllPessoas")]
        public async Task<ActionResult<List<Pessoa>>> GetAll()
        {
            return await _genericRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoaById(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaDTO>> Create(PessoaDTO pessoaDto)

        {
            //convertendo manualmente o DTO para a entidade. Posso fazer com AutoMapper
            Pessoa pessoa = new Pessoa();
            pessoa.email = pessoaDto.email;

            _genericRepository.Create(pessoa);

            //existe uma convenção para retornar a referencia(location) da entidade criada
            return CreatedAtAction(nameof(GetPessoaById), new { id = pessoa.id }, pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _genericRepository.Delete(id);
            return Ok();
        }
    }
}
