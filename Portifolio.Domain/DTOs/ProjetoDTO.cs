using System.ComponentModel.DataAnnotations;

namespace Portifolio.Domain.DTOs
{
    //DTO, Data Transfer Object.
    //Esse tipo de classe é um padrãp usado para transferencia de alguns dados especificos,
    //como se fosse uma espécie de filtragem
    //POST PARA INSERIR 
    public class ProjetoDTO
    {
        //para o Post Criar pessoa
        [Required]
        [StringLength(200)]
        public string nome { get; set; }
        
        [StringLength(200)]
        public string descricao { get; set; }

        [Required]      
        public string pessoaId { get; set; }


    }

    //POST PARA LISTAR
    public class ProjetoListDTO : ProjetoDTO
    {
        [Key]
        public int id { get; set; }
    }
}
