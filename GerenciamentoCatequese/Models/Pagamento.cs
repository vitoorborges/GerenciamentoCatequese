namespace GerenciamentoCatequese.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public int IdTipoPagamento { get; set; }
        public string? NomeResponsavelPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
