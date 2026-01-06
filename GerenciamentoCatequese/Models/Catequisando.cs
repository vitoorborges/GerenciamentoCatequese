namespace GerenciamentoCatequese.Models
{
    public class Catequisando
    {
        public int IdCatequisando { get; set; }
        public string? NomeCatequisando { get; set; }
        public DateTime? DataNascimento { get; set; } // Pode ser nulo
        public string? UFNaturalidade { get; set; }
        public string? MunicipioNaturalidade { get; set; }
        public bool Batizado { get; set; } // Pode ser nulo
        public DateTime? DataBatismo { get; set; }
        public string? UFBatismo { get; set; }
        public string? MunicipioBatismo { get; set; }
        public string? ParoquiBatismo { get; set; }
        public bool Eucaristia { get; set; } // Pode ser nulo
        public DateTime? DataEucaristia { get; set; }
        public string? UFEucatistia { get; set; }
        public string? MunicipioEucaristia { get; set; }
        public string? ParoquiaEucaristia { get; set; }
        public bool Pastoral { get; set; } // Pode ser nulo
        public string? DescricaoPastoral { get; set; }
        public string? CepEndereco { get; set; }
        public string? UFEndereco { get; set; }
        public string? LogradouroEndereco { get; set; }
        public string? BairroEndereco { get; set; }
        public string? CidadeEndereco { get; set; }
        public string? NumeroEndereco { get; set; }
        public string? ComplementoEndereco { get; set; }
        public string? Email { get; set; }
        public string? TelefoneResidencial { get; set; }
        public string? TelefoneCelular { get; set; }
        public int IdTurma { get; set; }
        public int Idade { get; set; }
        public string? DescricaoTurma { get; set; }
        public int AnoCatequese { get; set; }
    }


}
