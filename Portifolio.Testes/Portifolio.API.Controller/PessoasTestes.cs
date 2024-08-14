using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Portifolio.Controllers;
using Portifolio.Domain.DTOs;
using Portifolio.Domain.Entities;
using Portifolio.Domain.Interfaces;
using Portifolio.Infra.Data.Context;
using System.Net;
using System.Web.Http;


namespace Portifolio.Testes.Portifolio.API.Controller
{
    
    public class PessoasTestes
    {
        [Fact]
        public void CriarPessaTeste() {
            //Arrange
            IPessoa context = null;
            IMapper mapper = null;
            var controller = new PessoaController(context, mapper);

            var pessoaDto = new PessoaDTO();
            pessoaDto.nome = "Mateus Dias dos Santos";
            pessoaDto.email = "teste@gmail.com";

            //act
            var result = controller.Create(pessoaDto);

            //var actionResult = controller.Delete(1);

            //assert
            Assert.NotNull(result);  
        }

    }
}
