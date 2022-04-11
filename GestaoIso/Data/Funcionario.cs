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

        //[Display(Name = "Experiência Atual")]
        //public string ExperienciaAtual { get; set; }

        //[Display(Name = "Anexo Experiência")]
        //[DataType(DataType.ImageUrl)]
        //public string AnexoExperiencia { get; set; }

        //[Display(Name = "Educação Atual")]
        //public int DominioIdEducacao { get; set; }
        //public Dominio? DominioEducacao { get; set; }

        //[Display(Name = "Anexo Educacação")]
        //[DataType(DataType.ImageUrl)]
        //public string AnexoEducacao { get; set; }

        //[Display(Name = "Treinamento Atual")]
        //public string TreinamentoAtual { get; set; }

        //[Display(Name = "Anexo Treinamento")]
        //[DataType(DataType.ImageUrl)]
        //public string AnexoTreinamento { get; set; }



        [Display(Name = "Cadastrado por")]
        public string? CriacaoResp { get; set; }


        [Display(Name = "Cadastrado em")]
        public DateTime? CriacaoData { get; set; }


        [Display(Name = "Revisado por")]
        public string? RevisaoResp { get; set; }


        [Display(Name = "Revisado em")]
        public DateTime? RevisaoData { get; set; }


    }
}
