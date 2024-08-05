using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortifolioAPI.Models
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Key]
        public int id { get; set; }
        public string? nome { get; set; }
        [EmailAddress]
        public string email { get; set; }

        public Pessoa() { }

        public Pessoa(int id, string nome, string email)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
        }
    }
}
