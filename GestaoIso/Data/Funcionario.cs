using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoIso.Data
{
    public class Funcionario
    {
        [Key]
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PessoaIdFuncionario { get; set; }

        public virtual Pessoa? Pessoa { get; set; }




        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }


        [Display(Name = "Função")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public int FuncaoId { get; set; }
        public Funcao? Funcao { get; set; }
    }
}
