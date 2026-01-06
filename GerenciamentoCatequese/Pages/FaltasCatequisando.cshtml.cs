using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciamentoCatequese.Pages
{
    public class FaltasCatequisandoModel : PageModel
    {
        private readonly IGerenciamentoService _gerenciamentoService;

        public IEnumerable<Catequisando> _catquisando { get; set; } = Enumerable.Empty<Catequisando>();

        public IEnumerable<Turma> _turmas { get; set; } = Enumerable.Empty<Turma>();

        public string? IdPerfilClaim { get; set; } = null;
        public string? IdTurmaClaim { get; set; } = null;

        public FaltasCatequisandoModel(IGerenciamentoService gerenciamentoService)
        {
            _gerenciamentoService = gerenciamentoService;
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

            _catquisando = await _gerenciamentoService.ListaCatequisandos(idPerfil, IdTurma, 2025);

            _turmas = await _gerenciamentoService.ListarTurmas();

            return Page();
        }
    }
}
