namespace GerenciamentoCatequese.Models
{
    public class PagamentoTaxa
    {
        public int IdCatequisando { get; set; }
        public int IdTurma { get; set; }
        public string? Parcela { get; set; }
        public DateTime DataPagamento { get; set; }
        public string? ValorPagamento { get; set; }
        public string? NomeResponsavel { get; set; }
    }
}
