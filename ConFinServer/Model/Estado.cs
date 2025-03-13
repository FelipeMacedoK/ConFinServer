using System;
using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Estado
    {
        [Key]
        [StringLength(2
                     , MinimumLength=2
                     , ErrorMessage = "Obrigatório informar dois caracteres")]
        public string Sigla { get; set; }
        [Required(ErrorMessage ="Obrigatório informar o nome do estado")]
        [StringLength(50
                     , MinimumLength = 3
                     , ErrorMessage = "O nome do estado deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }
    }
}