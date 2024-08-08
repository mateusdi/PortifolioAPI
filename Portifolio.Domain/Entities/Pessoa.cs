﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Domain.Entities
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string senha { get; set; }
        public List<Projeto> projetos { get; set; }
        public Pessoa() { }

        public Pessoa(int id, string nome, string email, string senha, List<Projeto> projetos)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.projetos = projetos;
        }
    }
}
