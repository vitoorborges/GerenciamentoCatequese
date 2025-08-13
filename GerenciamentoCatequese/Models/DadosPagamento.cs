namespace GerenciamentoCatequese.Models
{
    public class DadosPagamento
    {
        public int IdDadosPagamento { get; set; }
        public int IdTipoPagamento { get; set; }
        public string? NomeResponsavelPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string? DescricaoTipoPagamento { get; set; }
    }
}
