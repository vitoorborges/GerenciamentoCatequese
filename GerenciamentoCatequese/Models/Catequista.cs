namespace GerenciamentoCatequese.Models
{
    public class Catequista
    {
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int IdTurma { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int Perfil { get; set; }
        public string? Senha { get; set; }
        public string? DescricaoTurma { get; set; }
        public string? DescricaoPerfil { get; set; }
        public string? Foto { get; set; }
    }
}
