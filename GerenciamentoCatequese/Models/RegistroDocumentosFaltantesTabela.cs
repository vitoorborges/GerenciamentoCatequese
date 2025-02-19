namespace GerenciamentoCatequese.Models
{
    public class RegistroDocumentosFaltantesTabela
    {
        
        public int IdCatequizando { get; set; }
        public string? NomeCatequizando { get; set; }
        public string? DescricaoTurma { get; set; }
        public string? NomeResponsavel { get; set; }
        public string? TelefoneResponsavel { get; set; }
        public string? TelefoneResponsavelFixo { get; set; }
        public string? DescricaoDocumentosFaltantes { get; set; }
        public string? LocalidadeDocumento { get; set; }
        public string? PrazoEntrega { get; set; }

    }
}
