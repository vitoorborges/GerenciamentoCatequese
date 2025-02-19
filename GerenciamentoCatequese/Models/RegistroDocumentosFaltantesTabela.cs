namespace GerenciamentoCatequese.Models
{
    public class RegistroDocumentosFaltantesTabela
    {
        public int IdRegistroDocumentosFaltantes { get; set; }
        public int IdCatequizando { get; set; }
        public string? DescricaoDocumentosFaltantes { get; set; }
        public string? DescricaoTurma { get; set; }
        public string? DescricaoPrazo { get; set; }
        public string? NomeCatequizando { get; set; }
        public string? TelefoneResponsavel { get; set; }

    }
}
