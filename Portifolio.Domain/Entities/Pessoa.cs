using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Domain.Entities
{
    [Table("pessoa")]
    public class Pessoa
    {
        

        public int id { get; set; }
        public string nome { get; set; }
        [EmailAddress]
        public string email { get; set; }
        
        public List<Projeto> projetos { get; set; } = new List<Projeto>(); //remover o alto acoplamento

        public Usuario usuario { get; set; }
        public Pessoa() { }

        public Pessoa(int id, string nome, string email, string senha, List<Projeto> projetos)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.projetos = projetos;
        }
    }
}
