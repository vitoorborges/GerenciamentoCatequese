namespace GerenciamentoCatequese.Models
{
    public class RegistroDocumentosFaltantesRequisicao
    {
        public string? NomeCatequizando { get; set; }
        public string? NomeResponsavel { get; set; }
        public string? TelefoneResponsavel { get; set; }
        public int IdTurma { get; set; }
        public string? TelefoneResponsavelFixo { get; set; }
        public int IdPrazoDocumentoFaltante { get; set; }
        public int IdDocumentoFaltante { get; set; }
        public DateTime PrazoEntrega { get; set; }
    }
}
