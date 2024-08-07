using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Domain.Entities
{
    [Table("projeto")]
    public class Projeto
    {
        [Key]
        public int id { get; set; }
        public string? nome { get; set; }
        public string? descricao { get; set; }

        public Projeto() { }

        public Projeto(int id, string nome, string descricao)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
        }
    }
}
