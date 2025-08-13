using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciamentoCatequese.Pages
{
    public class CatequistaCadastroModel : PageModel
    {
        [BindProperty]
        public string ImagemBase64 { get; set; } = string.Empty;
        [BindProperty]
        public Catequista Catequista { get; set; } = new Catequista();

        public IEnumerable<Turma> _turmas { get; set; } = Enumerable.Empty<Turma>();

        private readonly IGerenciamentoService _gerenciamento;

        public CatequistaCadastroModel(IGerenciamentoService gerenciamento)
        {
            _gerenciamento = gerenciamento;
        }

        public async Task<IActionResult> OnGet()
        {
            _turmas = await _gerenciamento.ListarTurmas();
            return Page();
        }

        public async Task<IActionResult> OnPostSalvarImagem()
        {           

            var base64 = ImagemBase64.Substring(ImagemBase64.IndexOf(',') + 1);
            byte[] imageBytes = Convert.FromBase64String(base64);

            var nomeArquivo = $"foto_{Catequista.Nome?.Replace(" ", "")}.png";
            var caminhoCompleto = Path.Combine("wwwroot", "assets", nomeArquivo);

            // Cria pasta se não existir
            Directory.CreateDirectory(Path.GetDirectoryName(caminhoCompleto));

            // Salva o arquivo
            await System.IO.File.WriteAllBytesAsync(caminhoCompleto, imageBytes);

            var retorno = await _gerenciamento.InserirCatequista(Catequista);

            return RedirectToPage("Catequistas");
        }
    }
}
