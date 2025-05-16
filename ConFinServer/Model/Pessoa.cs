using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Pessoa
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome da pessoa")]
        [StringLength(50
                     , MinimumLength = 3
                     , ErrorMessage = "O nome da pessoa deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o código da cidade")]
        public int CodigoCidade { get; set; }

        public Cidade? Cidade { get; set; }

    }
}
