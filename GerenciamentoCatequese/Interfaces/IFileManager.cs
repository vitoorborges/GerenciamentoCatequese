using GerenciamentoCatequese.Models;
using System.Data;

namespace GerenciamentoCatequese.Interfaces
{
    public interface IFileManager
    {

        Task<DataTable> GerarExecelCompleto(IEnumerable<CatequisandoRelatorio> relatorioCompleto);
        Task<MemoryStream> GerarArquivo(DataTable tabela);
        Task<DataTable> GerarExcelFrequencia(IEnumerable<RelatorioFrequencia> relatorioFrequencia);
        Task<DataTable> GerarExcelFrequenciaCrismaAdulto(IEnumerable<RelatorioFrequencia> relatorioFrequencia);
        Task<DataTable> GerarExcelResponsaveis(IEnumerable<RelatorioResponsaveis> relatorioFrequencia);
        Task<DataTable> GerarExcelPagamentoTaxa(IEnumerable<RelatorioPagamentoTaxa> relatorioPagamento);
    }
}
