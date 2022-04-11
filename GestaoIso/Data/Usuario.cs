using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GestaoIso.Data
{
    [Index(nameof(UserName), IsUnique = true)]//sem duplicidade
    public class Usuario
    {
        [Key]
        public int UserId { get; set; }

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

        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }



        [Display(Name = "Criado por")]
        public string? CriacaoResp { get; set; }


        [Display(Name = "Criado em")]
        public DateTime? CriacaoData { get; set; }


        [Display(Name = "Revisado por")]
        public string? RevisaoResp { get; set; }


        [Display(Name = "Revisado em")]
        public DateTime? RevisaoData { get; set; }
    }
}
