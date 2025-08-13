using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using GerenciamentoCatequese.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace GerenciamentoCatequese.Pages
{
    public class CatequistaModel : PageModel
    {
        private readonly IGerenciamentoService _gerenciamento;
        public IEnumerable<Catequista> _catequistas { get; set; } = Enumerable.Empty<Catequista>();

        public CatequistaModel(IGerenciamentoService gerenciamento)
        {
            _gerenciamento = gerenciamento;
        }

        public async Task<IActionResult> OnGet()
        {
            _catequistas = await _gerenciamento.ListarCatequistas();

            return Page();
        }
    }
}
