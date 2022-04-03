using System.ComponentModel.DataAnnotations;

namespace GestaoIso.Data
{
    public class Pessoa
    {
        [Key]
        public int PessoaId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
        public string Sobrenome { get; set; }

        [Display(Name = "Nome completo")]
        public string NomeCompleto { get { return string.Format("{0} {1}", this.Nome, this.Sobrenome); } }

        [Display(Name = "CPF/CNPJ")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        //[StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
        public string CpfCnpj { get; set; }

        [Display(Name = "RG")]
        public string Rg { get; set; }


        // Logradouro
        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }




        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }





        [Display(Name = "Telefone residencial")]
        public string TelefoneResidencial { get; set; }

        [Display(Name = "Telefone celular")]
        public string TelefoneCelular { get; set; }

        [Display(Name = "Comentário")]
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }





        [Display(Name = "Criado por")]
        public string CriacaoResp { get; set; }

        [Display(Name = "Criado em")]
        public DateTime? CriacaoData { get; set; }

        [Display(Name = "Revisado por")]
        public string RevisaoResp { get; set; }
        [Display(Name = "Revisado em")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        public DateTime? RevisaoData { get; set; }


        //public Funcionario? Funcionario { get; set; }
    }
}
