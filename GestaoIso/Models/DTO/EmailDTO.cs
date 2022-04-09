namespace GestaoIso.Models.DTO
{
    public class EmailDTO
    {
        public string Titulo { get; set; }
        public string Mensagem { get; set; }

        public List<string> Para { get; set; }
        public List<string> CCO { get; set; }
        public List<string> CC { get; set; }
    }
}
