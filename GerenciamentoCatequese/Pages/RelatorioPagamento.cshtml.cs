using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciamentoCatequese.Pages
{
    public class RelatorioPagamentoModel (IGerenciamentoService gerenciamentoService, IFileManager file) : PageModel
    {

        public IEnumerable<RelatorioPagamentoTaxa> _pagamentos = Enumerable.Empty<RelatorioPagamentoTaxa>();

        public async Task<IActionResult> OnGet()
        {
            _pagamentos = await gerenciamentoService.GerarRelatorioPagamentoTaxa();

            return Page();
        }

        public async Task<IActionResult> OnPostGerarRelatorioPagamentoTaxa()
        {
            var retorno = await gerenciamentoService.GerarRelatorioPagamentoTaxa();

            var retornoExcel = await file.GerarExcelPagamentoTaxa(retorno);

            var retornoArquivo = await file.GerarArquivo(retornoExcel);

            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var fileName = "RelatorioPagamentoTaxa.xlsx";

            return File(retornoArquivo, contentType, fileName);
        }

        public async Task<IActionResult> OnPostDeletarPagamentoTaxa(int IdPagamentoTaxaExclusao)
        {
            await gerenciamentoService.DeletarPagamentoTaxa(IdPagamentoTaxaExclusao);
            return RedirectToPage("RelatorioPagamento");
        }

        
    }
}
