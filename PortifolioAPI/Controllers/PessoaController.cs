using Microsoft.AspNetCore.Mvc;

using PortifolioAPI.Interfaces;

using PortifolioAPI.Models;


namespace PortifolioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoa _pessoaRepository;
       
        public PessoaController(IPessoa pessoaRepository)
        {
            _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException(nameof(pessoaRepository));
        }

        //retorna todas as pessoas
        [HttpGet(Name = "GetAllPessoa")]
        public async Task<ActionResult<List<Pessoa>>> GetAllPessoa() 
        { 
            return await _pessoaRepository.GetAllAsync();
        }

        //retorna 1 pessoa por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoaById(int id)
        {
            return await _pessoaRepository.GetByIdAsync(id);
        }

        //Insere 1 pessoa
        [HttpPost]
        public async Task<ActionResult<PessoaDTO>> PostPessoa(PessoaDTO pessoaDto)

        {
            //convertendo manualmente o DTO para a entidade. Posso fazer com AutoMapper
            Pessoa pessoa = new Pessoa();
            pessoa.email = pessoaDto.email;

            _pessoaRepository.Create(pessoa);
            

            //existe uma convenção para retornar a referencia(location) da entidade criada
            return CreatedAtAction(nameof(GetPessoaById), new { id = pessoa.id }, pessoa);
        }
    }
}
