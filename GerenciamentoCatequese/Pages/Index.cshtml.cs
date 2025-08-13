using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Claims;

namespace GerenciamentoCatequese.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly IGerenciamentoService _gerenciamentoService;
        private readonly IFileManager _file;

        [BindProperty]
        public int _turmaRelatorio { get; set; } = 0;

        [BindProperty]
        public int _TipoRelatorio { get; set; } = 0;

        public IEnumerable<UsuarioModel> _usuarios = Enumerable.Empty<UsuarioModel>();
        public IEnumerable<Catequisando> _catquisando { get; set; } = Enumerable.Empty<Catequisando>();
        public IEnumerable<Turma> _turmas { get; set; } = Enumerable.Empty<Turma>();
        public string? IdPerfilClaim { get; set; } = null;
        public string? IdTurmaClaim { get; set; } = null;

        public IndexModel(ILogger<IndexModel> logger, IUsuarioService usuarioService, IGerenciamentoService gerenciamentoService, IFileManager file)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _gerenciamentoService = gerenciamentoService;
            _file = file;
        }

        public async Task<IActionResult> OnGet()
        {
            int idPerfil = 0;
            int IdTurma = 0;

            if (User.Identity?.IsAuthenticated == true)
            {
                // DescricaoPerfil já é uma propriedade da classe
                IdPerfilClaim = User.FindFirst("IdPerfil")?.Value;
                IdTurmaClaim = User.FindFirst("IdTurma")?.Value;

                if (int.TryParse(IdPerfilClaim, out int parsed))
                {
                    idPerfil = parsed;
                }

                if (int.TryParse(IdTurmaClaim, out int parsedTurma))
                {
                    IdTurma = parsedTurma;
                }
            }

            _catquisando = await _gerenciamentoService.ListaCatequisandos(idPerfil, IdTurma);
            _turmas = await _gerenciamentoService.ListarTurmas();

            return Page();
        }


        public async Task<IActionResult> OnPostExcluirCadastro(int IdCatequisandoParaExcluir)
        {
            await _gerenciamentoService.ExcluirCadastro(IdCatequisandoParaExcluir);
            return RedirectToPage("Index");
        }

       


        public async Task<IActionResult> OnPostGerarRelatorio()
        {
            IEnumerable<RelatorioFrequencia> retorno = Enumerable.Empty<RelatorioFrequencia>();
            IEnumerable<CatequisandoRelatorio> retornoCompleto = Enumerable.Empty<CatequisandoRelatorio>();
            IEnumerable<RelatorioResponsaveis> retornoResponsaveis = Enumerable.Empty<RelatorioResponsaveis>();
            DataTable retornoExcel = new DataTable();
            if (_turmaRelatorio != 5)
            {

                if (_TipoRelatorio == 1)
                {
                    retornoCompleto = await _gerenciamentoService.GerarRelatorioCompleto(_turmaRelatorio);
                    retornoExcel = await _file.GerarExecelCompleto(retornoCompleto);
                }
                else if (_TipoRelatorio == 2)
                {
                    retorno = await _gerenciamentoService.GerarRelatorioFrequencia(_turmaRelatorio);
                    retornoExcel = await _file.GerarExcelFrequencia(retorno);

                }else
                {
                    retornoResponsaveis = await _gerenciamentoService.GerarRelatorioResponsaveis(_turmaRelatorio);
                    retornoExcel = await _file.GerarExcelResponsaveis(retornoResponsaveis);
                }

            }
            else
            {
                if (_TipoRelatorio == 1)
                {
                    retornoCompleto = await _gerenciamentoService.GerarRelatorioCompleto(_turmaRelatorio);
                    retornoExcel = await _file.GerarExecelCompleto(retornoCompleto);
                }
                else if(_TipoRelatorio == 2)
                {
                    retorno = await _gerenciamentoService.GerarRelatorioFrequenciaCrismaAdulto(_turmaRelatorio);
                    retornoExcel = await _file.GerarExcelFrequenciaCrismaAdulto(retorno);
                }
                
            }



            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";


            var fileName = _TipoRelatorio == 1 ? "RelatorioCompleto.xlsx"
            : _TipoRelatorio == 2 ? "RelatorioFrequencia.xlsx"
            : _TipoRelatorio == 3 ? "RelatorioResponsaveis.xlsx"
            : "RelatorioPadrao.xlsx";

            var retornoArquivo = await _file.GerarArquivo(retornoExcel);

            return File(retornoArquivo, contentType, fileName);
        }


    }
}
