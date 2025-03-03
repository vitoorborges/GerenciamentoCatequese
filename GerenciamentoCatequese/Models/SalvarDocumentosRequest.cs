namespace GerenciamentoCatequese.Models
{
    public class SalvarDocumentosRequest
    {
        public List<DocumentosEntregues>? Documentos { get; set; }
        public Pagamento? Pagamento { get; set; }
    }
}
