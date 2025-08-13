namespace GerenciamentoCatequese.Models
{
    public class SalvarDocumentosRequest
    {
        public List<DocumentosEntregues>? Documentos { get; set; }
        public DadosPagamento? Pagamento { get; set; }
        public int IdCatequisando { get; set; }
    }
}
