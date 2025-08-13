using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciamentoCatequese.Pages
{
    public class PagamentoTaxaModel : PageModel
    {
        [BindProperty]
        public PagamentoTaxa _pagamentoTaxa { get; set; }

        [BindProperty(SupportsGet = true)]
        public int IdCatequisando { get; set; } = new();

        private readonly IGerenciamentoService _gerenciamentoService;
        public Catequisando _catequisando { get; set; } = new();
        public IEnumerable<ResponsavelCatequisando> _responsaveis { get; set; } = Enumerable.Empty<ResponsavelCatequisando>();
        public IEnumerable<RegistroPagamentosTaxa> _registroPagamentosTaxas { get; set; } = Enumerable.Empty<RegistroPagamentosTaxa>();

        public IEnumerable<Turma> _turmas { get; set; } = Enumerable.Empty<Turma>();
        public PagamentoTaxaModel(IGerenciamentoService gerenciamentoService)
        {
            _gerenciamentoService = gerenciamentoService;
        }

        public async Task<IActionResult> OnGet()
        {
            _registroPagamentosTaxas = await _gerenciamentoService.ListarRegistrosPagamentosTaxa(IdCatequisando);
            _turmas = await _gerenciamentoService.ListarTurmas();
            _catequisando = await _gerenciamentoService.PesquisaCatequisando(IdCatequisando);
           _responsaveis = await _gerenciamentoService.ListarResponsaveisCatequisando(IdCatequisando);

            return Page();
        }

        public async Task<IActionResult> OnPostEnviarFormulario()
        {

            var retorno = await _gerenciamentoService.GravarPagamentoTaxa(_pagamentoTaxa);

            return RedirectToPage("PagamentoTaxa", new { IdCatequisando = _pagamentoTaxa.IdCatequisando});
        }

     
    }
}
