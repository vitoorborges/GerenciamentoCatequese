using GerenciamentoCatequese.Models;
using System.Data;

namespace GerenciamentoCatequese.Interfaces
{
    public interface IGerenciamentoService
    {
        Task<IEnumerable<Catequisando>> ListaCatequisandos(int IdPerfil, int IdTurma, int AnoCatequese);
        Task<IEnumerable<Turma>> ListarTurmas();
        Task<IEnumerable<Documento>> ListarDocumentos();
        Task<int> GravarDadosPessoais(Catequisando catequisando);
        Task<IEnumerable<TipoParentesco>> ListarParentesco();
        Task<int> GravarDadosResponsavel(ResponsavelCatequisando _responsavelCatequisando);
        Task<int> GravarDocumentoEntregue(DocumentosEntregues documentosEntregues, int idCatequisando);
        Task<int> GravarDadosPagamento(DadosPagamento dadosPagamento, int IdCatequisando);
        Task<Catequisando> PesquisaCatequisando(int IdCatequisando);
        Task<int> AtualizarDadosCatequisando(Catequisando catequisando, int IdCatequisando);
        Task<IEnumerable<ResponsavelCatequisando>> ListarResponsaveisCatequisando(int IdCatequisando);
        Task<IEnumerable<DocumentosEntregues>> ListarDocumentosEntregues(int IdCatequisando);
        Task<DadosPagamento> ListarDadosPagamento(int IdCatequisando);
        Task<int> AtualizarDadosResponsavel(ResponsavelCatequisando responsavel, int IdResponsavelCatequisando);
        Task<IEnumerable<CatequisandoRelatorio>> GerarRelatorioCompleto(int IdTurma);
        Task<IEnumerable<RelatorioFrequencia>> GerarRelatorioFrequencia(int IdTurma);
        Task<IEnumerable<RelatorioFrequencia>> GerarRelatorioFrequenciaCrismaAdulto(int IdTurma);
        Task<IEnumerable<RelatorioFrequencia>> GravarObservacoes(int IdCatequisando, string ObservacoesGerais);
        Task<string> ListarObservacoes(int IdCatequisando);
        Task<IEnumerable<RelatorioResponsaveis>> GerarRelatorioResponsaveis(int IdTurma);
        Task ExcluirCadastro(int IdCatequisando);
        Task<int> InserirCatequista(Catequista catequista);
        Task<IEnumerable<Catequista>> ListarCatequistas();
        Task<int> GravarPagamentoTaxa(PagamentoTaxa pagamentoTaxa);
        Task<IEnumerable<RegistroPagamentosTaxa>> ListarRegistrosPagamentosTaxa(int IdCatequisando);
        Task<IEnumerable<RelatorioPagamentoTaxa>> GerarRelatorioPagamentoTaxa();
        Task DeletarPagamentoTaxa(int IdPagamentoTaxa);
        Task<Catequista> PesquisaCatequista(int IdCatequista);
        Task<int> AtualizarCatequista(Catequista catequista, int idCatequista);
        Task RegistrarFrequenciaCatequisando(int IdTurma, DateTime DataFrequencia, DataTable frequenciaCatequisandos);
        Task<IEnumerable<RelatorioFrequenciaLancada>> GerarRelatorioFrequenciaLancada();

    }
}
