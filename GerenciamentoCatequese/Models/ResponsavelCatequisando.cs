namespace GerenciamentoCatequese.Models
{
    public class ResponsavelCatequisando
    {
        public int IdResponsavelCatequisando { get; set; }
        public int IdCatequisando { get; set; }
        public int? IdTipoParentesco { get; set; }
        public string? NomeResponsavel { get; set; }
        public DateTime? DataNascimentoResponsavel { get; set; }
        public string? Religiao { get; set; }
        public string? ProfissaoResponsavel { get; set; }
        public DateTime? DataCasamento { get; set; }
        public bool Batismo { get; set; }
        public bool Eucaristia { get; set; }
        public bool Crisma { get; set; }
        public bool Matrimonio { get; set; }
        public bool OutraPastoral { get; set; }
        public string? DescricaoOutraPastoral { get; set; }
        public bool Dizimista { get; set; }
        public string? TelefoneCelular { get; set; }
        public string? DescricaoParentesco { get; set; }
    }

}
