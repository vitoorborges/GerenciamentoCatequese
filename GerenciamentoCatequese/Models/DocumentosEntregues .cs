namespace GerenciamentoCatequese.Models
{
    public class DocumentosEntregues
    {
        public int IdCatequisando { get; set; }
        public int IdTipoDocumento { get; set; }
        public bool Entregue { get; set; }
        public string? LocalDocumento { get; set; }
    }
}
