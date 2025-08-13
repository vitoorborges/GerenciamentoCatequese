namespace GerenciamentoCatequese.Models
{
    public class RelatorioFrequencia
    {
        public int IdCatequisando { get; set; }
        public string? NomeCatequisando { get; set; }
        public string? DescricaoTurma { get; set; }
        public string? DataNascimento { get; set; } // Data já formatada como string (dd/MM/yyyy)
        public string? NomeResponsavel { get; set; }
        public string? TelefoneCelular { get; set; }
        public int Idade { get; set; }
    }
}
