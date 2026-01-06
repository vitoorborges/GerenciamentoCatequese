namespace GerenciamentoCatequese.Models
{
    public class Catequista
    {
        public int idCatequista { get; set; }
        public int IdTurma { get; set; }
        public string? NomeCatequista { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public int IdPerfil { get; set; }
        public int Trabalha { get; set; }
        public string? Profissao { get; set; }
        public string? Disponibilidade { get; set; }
        public string? TamanhoCamiseta { get; set; }
        public string? EstadoCivil { get; set; }
        public int? Pastoral { get; set; }
        public string? DescricaoPastoral { get; set; }
        public string? Senha { get; set; }
        public string? DescricaoTurma { get; set; }
        public string? DescricaoPerfil { get; set; }
        public string? Foto { get; set; }
        public int Batismo { get; set; }
        public int Eucaristia { get; set; }
        public int Crisma { get; set; }
        public int Matrimonio { get; set; }
        public List<SacaramentosCatequista>? Sacramentos { get; set; }
    }
}
