using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace GerenciamentoCatequese.Pages
{
    public class RelatorioFrequenciaLancadaModel(IGerenciamentoService gerenciamentoService) : PageModel
    {

        public IEnumerable<RelatorioFrequenciaLancada> _frequencias = Enumerable.Empty<RelatorioFrequenciaLancada>();
        public async Task<IActionResult> OnGet()
        {
            _frequencias = await gerenciamentoService.GerarRelatorioFrequenciaLancada();

            return Page();
        }
    }
}
