using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.DTOs;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Interfaces;
using Portifolio.Infra.Data.Repositories;

namespace Portifolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoa _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaController(IPessoa genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _pessoaRepository = genericRepository;
        }

        [HttpGet(Name = "GetAllPessoas")]
        public async Task<ActionResult<List<Pessoa>>> GetAll()
        {
            var pessoas = await _pessoaRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PessoaDTO>>(pessoas));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPessoaById(int id)
        {
            var pessoa = _pessoaRepository.GetByIdAsync(id);
            var pessoaDTO = _mapper.Map<PessoaListDTO>(pessoa);
            return Ok(pessoaDTO);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaDTO>> Create(PessoaDTO pessoaDto)
        {
            _pessoaRepository.Create(_mapper.Map<Pessoa>(pessoaDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _pessoaRepository.Delete(id);
            return Ok();
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
