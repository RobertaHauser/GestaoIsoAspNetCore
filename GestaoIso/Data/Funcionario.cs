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



        [Display(Name = "Data Admissão")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataAdmissao { get; set; }

        [Display(Name = "Data Demissão")]
        [DataType(DataType.Date)]
        public DateTime? DataDemissao { get; set; }


        [Display(Name = "Função")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public int FuncaoId { get; set; }
        public Funcao? Funcao { get; set; }
    }
}
