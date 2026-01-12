namespace GerenciamentoCatequese.Models.Dtos
{
    public class FrequenciaRequestDTO
    {
        public DateTime DataFrequencia { get; set; }
        public List<FrequenciaCatequisando> Frequencias { get; set; } = new();
    }
}
