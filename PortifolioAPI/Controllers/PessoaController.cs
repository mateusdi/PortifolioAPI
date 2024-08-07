using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.DTOs;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Interfaces;

namespace Portifolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoa _pessoaRepository;

        public PessoaController(IPessoa genericRepository)
        {
            _pessoaRepository = genericRepository ?? throw new ArgumentNullException(nameof(genericRepository));
        }

        [HttpGet(Name = "GetAllPessoas")]
        public async Task<ActionResult<List<Pessoa>>> GetAll()
        {
            return await _pessoaRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoaById(int id)
        {
            return await _pessoaRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaDTO>> Create(PessoaDTO pessoaDto)
        {
            //convertendo manualmente o DTO para a entidade. Posso fazer com AutoMapper
            Pessoa pessoa = new Pessoa();
            pessoa.email = pessoaDto.email;

            _pessoaRepository.Create(pessoa);

            //existe uma convenção para retornar a referencia(location) da entidade criada
            return CreatedAtAction(nameof(GetPessoaById), new { pessoa.id }, pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _pessoaRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Pessoa pessoa)
        {
            _pessoaRepository.Update(pessoa);
            //retornar alguma coisa se for sucesso
            return CreatedAtAction(nameof(Pessoa), new { pessoa.id }, pessoa);
        }
    }
}
