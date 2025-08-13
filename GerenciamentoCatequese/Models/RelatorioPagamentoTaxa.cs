namespace GerenciamentoCatequese.Models
{
    public class RelatorioPagamentoTaxa
    {
        public int IdPagamentoTaxa { get; set; }
        public string? NomeCatequisando { get; set; }
        public string? DescricaoTurma { get; set; }
        public string? Parcela { get; set; }
        public DateTime DataPagamento { get; set; }
        public string? ValorPagamento { get; set; }
        public string? NomeResponsavel { get; set; }
    }
}
