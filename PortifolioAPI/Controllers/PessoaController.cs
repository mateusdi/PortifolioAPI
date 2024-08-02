using Microsoft.AspNetCore.Mvc;
using PortifolioAPI.Interfaces;
using PortifolioAPI.Model;


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

        [HttpPost]
        public ActionResult<Pessoa> PostTodoItem(Pessoa pessoa)
        {
            _pessoaRepository.Add(pessoa);
            return Ok();
        }
    }
}
