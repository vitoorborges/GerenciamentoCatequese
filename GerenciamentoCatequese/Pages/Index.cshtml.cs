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
        private readonly IFileManager _file;

        public IEnumerable<UsuarioModel> _usuarios;
        public IEnumerable<RegistroDocumentosFaltantesTabela> _documentosFaltantes {  get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUsuarioService usuarioService, IGerenciamentoService gerenciamentoService, IFileManager file)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _gerenciamentoService = gerenciamentoService;
            _file = file;
        }

        public async Task<IActionResult> OnGet()
        {
            _documentosFaltantes = await _gerenciamentoService.PesquisaRegistros();
            return Page();
        }

        public async Task<IActionResult> OnGetGerarArquivo()
        {
            _documentosFaltantes = await _gerenciamentoService.PesquisaRegistros();
            var retornoExcel = await _file.GerarExecel(_documentosFaltantes);
            
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var fileName = "DocumentosFaltantes.xlsx";

            var retornoArquivo = await _file.GerarArquivo(retornoExcel);

            return File(retornoArquivo, contentType, fileName);
        }
    }
}
