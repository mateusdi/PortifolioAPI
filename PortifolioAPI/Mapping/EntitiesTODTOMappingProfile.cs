using AutoMapper;
using Portifolio.Domain.DTOs;
using Portifolio.Domain.Entities;

namespace Portifolio.API.Mapping
{
    public class EntitiesTODTOMappingProfile : Profile
    {
        public EntitiesTODTOMappingProfile() 
        {
            //para Post
            CreateMap<Pessoa, PessoaLisDTO>().ReverseMap();

            //CreateMap<Unidade, EscolaDTO>().ReverseMap();
        }
    }
}
