namespace GerenciamentoCatequese.Models
{
    public class DocumentosEntregues
    {
        public int IdEntrega { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdCatequisando { get; set; }
        public bool Entregue { get; set; }
        public string? LocalDocumento { get; set; }
        public string? DescricaoTipoDocumento { get; set; }
    }
}
