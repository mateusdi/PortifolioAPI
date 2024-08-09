using AutoMapper;
using Portifolio.Domain.DTOs;
using Portifolio.Domain.Entities;

namespace Portifolio.Application.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            //para criar pessoa Post
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<Pessoa, PessoaListDTO>().ReverseMap();

            CreateMap<Projeto, ProjetoDTO>().ReverseMap();
            CreateMap<Projeto, ProjetoListDTO>().ReverseMap();
        }
    }
}
