using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portifolio.Domain.Entities
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public int pessoaId { get; set; }
        public Pessoa pessoa { get; set; }

        public Usuario()
        {

        }    
        public Usuario(int id, string login, string password, int pessoaId, Pessoa pessoa)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.pessoaId = pessoaId;
            this.pessoa = pessoa;
        }
    }
}
