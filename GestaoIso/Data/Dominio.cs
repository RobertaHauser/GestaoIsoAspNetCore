using System.ComponentModel.DataAnnotations;

namespace GestaoIso.Data
{
    public class Dominio
    {
        [Key]
        public int DominioId { get; set; }
        public string Descricao { get; set; }
        public int? Ordem { get; set; }
        public string Tabela { get; set; }


        //public ICollection<Funcao>? FuncaoEducacao { get; set; }
    }
}
