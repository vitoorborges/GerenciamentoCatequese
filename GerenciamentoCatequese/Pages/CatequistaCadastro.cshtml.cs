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
        public Catequista _catequista { get; set; } = new Catequista();

        [BindProperty]
        public List<int> SelectedSacramentos { get; set; } = new List<int>();

        [BindProperty(SupportsGet = true)]
        public int IdCatequistaEditar { get; set; } = new();

        public IEnumerable<SacaramentosCatequista> _sacramentos { get; set; } = Enumerable.Empty<SacaramentosCatequista>();

        public IEnumerable<Turma> _turmas { get; set; } = Enumerable.Empty<Turma>();

        private readonly IGerenciamentoService _gerenciamento;

        public CatequistaCadastroModel(IGerenciamentoService gerenciamento)
        {
            _gerenciamento = gerenciamento;
        }

        public async Task<IActionResult> OnGet()
        {
           _turmas = await _gerenciamento.ListarTurmas();

            _sacramentos = new List<SacaramentosCatequista>
            {
                new SacaramentosCatequista { IdSacramento = 1, DescricaoSacramento = "Batismo" },
                new SacaramentosCatequista { IdSacramento = 2, DescricaoSacramento = "Eucaristia" },
                new SacaramentosCatequista { IdSacramento = 3, DescricaoSacramento = "Crisma" },
                new SacaramentosCatequista { IdSacramento = 4, DescricaoSacramento = "Matrimonio" }
            };

            if (IdCatequistaEditar != 0)
            {
                _catequista = await _gerenciamento.PesquisaCatequista(IdCatequistaEditar);

                SelectedSacramentos = new List<int>();

                if (_catequista.Batismo == 1) SelectedSacramentos.Add(1);
                if (_catequista.Eucaristia == 1) SelectedSacramentos.Add(2);
                if (_catequista.Crisma == 1) SelectedSacramentos.Add(3);
                if (_catequista.Matrimonio == 1) SelectedSacramentos.Add(4);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSalvarImagem()
        {
            // Converte ids selecionados para objetos Sacramentos no modelo
            if (SelectedSacramentos != null && SelectedSacramentos.Any())
            {
                _catequista.Sacramentos = SelectedSacramentos
                    .Select(id => new SacaramentosCatequista { IdSacramento = id })
                    .ToList();
            }
            else
            {
                _catequista.Sacramentos = new List<SacaramentosCatequista>();
            }


            if (ImagemBase64 != null && ImagemBase64 != "")
            {
                var base64 = ImagemBase64.Substring(ImagemBase64.IndexOf(',') + 1);
                byte[] imageBytes = Convert.FromBase64String(base64);

                var nomeArquivo = $"foto_{_catequista.NomeCatequista?.Replace(" ", "")}.png";
                var caminhoCompleto = Path.Combine("wwwroot", "assets", nomeArquivo);

                // Cria pasta se não existir
                Directory.CreateDirectory(Path.GetDirectoryName(caminhoCompleto)!);

                // Salva o arquivo
                await System.IO.File.WriteAllBytesAsync(caminhoCompleto, imageBytes);

                _catequista.Foto = Path.Combine("assets/", nomeArquivo);

            }

            if (IdCatequistaEditar != 0)
            {
                var retorno = await _gerenciamento.AtualizarCatequista(_catequista, IdCatequistaEditar);
            }
            else
            {

                var retorno = await _gerenciamento.InserirCatequista(_catequista);
            }

            return RedirectToPage("Catequistas");
        }
    }
}
