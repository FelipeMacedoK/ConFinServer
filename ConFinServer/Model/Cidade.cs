using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConFinServer.Model
{
    public class Cidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o nome da cidade")]
        [StringLength(50
                     , MinimumLength = 3
                     , ErrorMessage = "O nome da cidade deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o estado")]
        [StringLength(2
                     , MinimumLength = 2
                     , ErrorMessage = "O estado deve ter 2 caracteres")]
        [ForeignKey("Estado")]
        public string Estado { get; set; }
    }
}
