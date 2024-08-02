using Microsoft.AspNetCore.Mvc;
using PortifolioAPI.Dados;
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

        [HttpGet(Name = "GetPessoa")]
        public IActionResult Get()
        {
            var pessoas = _pessoaRepository.Get();
            return Ok(pessoas);
        }
    }
}
