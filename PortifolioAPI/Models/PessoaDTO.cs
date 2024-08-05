using System.ComponentModel.DataAnnotations;

namespace PortifolioAPI.Models
{
    //DTO, Data Transfer Object.
    //Esse tipo de classe é um padrãp usado para transferencia de alguns dados especificos,
    //como se fosse uma espécie de filtragem
    public class PessoaDTO
    {
        public int id { get; set; }
        public string email { get; set; }



    }
}
