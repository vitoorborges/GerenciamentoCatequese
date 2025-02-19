using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciamentoCatequese.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly IGerenciamentoService _gerenciamentoService;

        public IEnumerable<UsuarioModel> _usuarios;
        public IEnumerable<RegistroDocumentosFaltantesTabela> _documentosFaltantes {  get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUsuarioService usuarioService, IGerenciamentoService gerenciamentoService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _gerenciamentoService = gerenciamentoService;
        }

        public async Task<IActionResult> OnGet()
        {
            _documentosFaltantes = await _gerenciamentoService.PesquisaRegistros();
            return Page();
        }
    }
}
