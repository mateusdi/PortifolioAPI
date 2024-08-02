using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortifolioAPI.Model
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Key]
        public int id { get; set; }

        public string nome{ get; set; }

        [EmailAddress]
        public string email { get; set; }

        /*
          public string? gitHub { get; set; }


          [MinLength(2)]
          public string? linkedin { get; set; }

          [Phone]
          public string phoneNumber { get; set; }

          [EmailAddress]
          public string email { get; set; }
        */


    }
}
