namespace GerenciamentoCatequese.Models
{
    public class RegistroPagamentosTaxa
    {
        public string? NomeCatequisando { get; set; }
        public string? NomeResponsavelCompleto { get; set; }
        public string? DescricaoTurma { get; set; }
        public string? Parcela { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string? ValorPagamento { get; set; }
    }
}
