using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper _mapper;

        public PessoaController(IPessoa genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _pessoaRepository = genericRepository;
        }

        [HttpGet(Name = "GetAllPessoas")]
        public async Task<ActionResult<List<PessoaListDTO>>> GetAll()
        {
            var pessoas = await _pessoaRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PessoaListDTO>>(pessoas));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPessoaById(int id)
        {
            var pessoa = await _pessoaRepository.GetByIdAsync(id);
            var pessoaDTO = _mapper.Map<PessoaListDTO>(pessoa);
            return Ok(pessoaDTO);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaDTO>> Create(PessoaDTO pessoaDto)
        {
            await _pessoaRepository.Create(_mapper.Map<Pessoa>(pessoaDto));
            return Ok(pessoaDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pessoaRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, PessoaDTO pessoaDto)
        {
            //atualiza a entidade toda
            await _pessoaRepository.Update(id, _mapper.Map<Pessoa>(pessoaDto));
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPessoa(int id, [FromBody] JsonPatchDocument<Pessoa> patchDoc)
        {
            //atualiza parcialmente a entidade
            var pessoa = await _pessoaRepository.GetByIdAsync(id);

            patchDoc.ApplyTo(pessoa, ModelState);

            await _pessoaRepository.Update(id, pessoa);
            return Ok();
        }
    }
}
