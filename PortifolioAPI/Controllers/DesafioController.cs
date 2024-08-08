using Microsoft.AspNetCore.Mvc;
using Portifolio.Domain.Entities;
using Portifolio.Infra.Data.Interfaces;

namespace Portifolio.API.Controllers
    /*
    Desafio feito por Luis Henrique da Hora Nascimento, desenvolvedor Sênior

    Quero que vc desenvolva uma API que mantenha na memória uma fila circular com a seguinte característica:
    A fila deve ter elementos com a seguinte estrutura:

    {
        "Nome": "String",
        "Tipo": Numero,
        "Mensagem": "String"
    }

    Ao inserir itens na fila, eles devem ser agrupados por tipo, na mesma ordem que forem inseridos(FIFO com categorias)
    */
{
    [ApiController]
    [Route("[controller]")]
    public class DesafioController : ControllerBase
    {
        private readonly IElementoRepository _elementoRepository;

        public DesafioController(IElementoRepository elementoRepository)
        {
            _elementoRepository = elementoRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Elemento>> Create(List<Elemento> elementos)
        {
           
            return Ok(_elementoRepository.Create(elementos));
        }
    }
}
