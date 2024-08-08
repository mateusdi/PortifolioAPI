using AutoMapper;
using Portifolio.Domain.DTOs;
using Portifolio.Domain.Entities;

namespace Portifolio.Application.Mappings
{
    public class EntitiesTODTOMappingProfile : Profile
    {
        public EntitiesTODTOMappingProfile()
        {
            //para criar pessoa Post
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            //para criar pessoa Get
            CreateMap<Pessoa, PessoaListDTO>().ReverseMap();
        }
    }
}
