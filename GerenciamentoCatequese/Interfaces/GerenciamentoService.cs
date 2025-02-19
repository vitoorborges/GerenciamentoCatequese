using GerenciamentoCatequese.Models;

namespace GerenciamentoCatequese.Interfaces
{
    public interface IGerenciamentoService
    {
        Task<IEnumerable<RegistroDocumentosFaltantesTabela>> PesquisaRegistros();
        Task<IEnumerable<Catequizando>> ListarCatequizandos();
        Task<IEnumerable<Prazo>> ListarPrazos();
        Task<IEnumerable<Turma>> ListarTurmas();
        Task<IEnumerable<DocumentoFaltante>> ListarDocumentos();
        Task Registar(RegistroDocumentosFaltantesRequisicao registro);
        Task<RegistroDocumentosFaltantesRequisicao> PesquisarRegistroCatequizando(int IdCatequizando);
        Task AlterarRegistro(RegistroDocumentosFaltantesRequisicao registro, int idCatequisando);
    }
}
