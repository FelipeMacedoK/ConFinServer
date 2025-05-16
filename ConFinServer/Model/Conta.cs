using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Conta
    {
        [Key]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Descrição")]
        [StringLength(50
                     , MinimumLength = 3
                     , ErrorMessage = "A descrição deve ter entre 3 e 50 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Tipo Conta é obrigatório")]
        public TipoConta Tipo { get; set; }

        [Required(ErrorMessage = "Situação é obrigatório")]
        public SituacaoConta Situacao { get; set; }

        [Required(ErrorMessage = "Pessoa é obrigatório")]
        public int CodigoPessoa { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}
