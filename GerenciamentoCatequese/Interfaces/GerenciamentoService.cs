using GerenciamentoCatequese.Models;

namespace GerenciamentoCatequese.Interfaces
{
    public interface IGerenciamentoService
    {
        Task<IEnumerable<Catequisando>> PesquisaCatequisando();
        Task<IEnumerable<Turma>> ListarTurmas();
        Task<IEnumerable<Documento>> ListarDocumentos();


    }
}
