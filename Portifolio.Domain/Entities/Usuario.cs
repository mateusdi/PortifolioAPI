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
        public int id { get; private set; }
        public string login { get; private set; }
        public byte[] passwordHash  { get; private set; }
        public byte[] passwordSalt { get; private set; }

        public int pessoaId { get; set; }
        public Pessoa pessoa { get; set; }

        public Usuario()
        {

        }    
        public Usuario(int id, string login, int pessoaId, Pessoa pessoa)
        {
            this.id = id;
            this.login = login;
            this.pessoaId = pessoaId;
            this.pessoa = pessoa;
        }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            this.passwordHash = passwordHash;
            this.passwordSalt = passwordSalt;
        }
    }
}
