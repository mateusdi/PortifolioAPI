using System.ComponentModel.DataAnnotations;

namespace Portifolio.Domain.DTOs
{
    //POST PARA INSERIR 
    public class PessoaDTO 
    {
        //para o Post Criar pessoa
        [Required]
        [StringLength(200)]
        public string nome { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string email { get; set; }
    
    }

    //POST PARA LISTAR
    public class PessoaListDTO : PessoaDTO
    {
        [Key]
        public int id { get; set; } 
    }
}
