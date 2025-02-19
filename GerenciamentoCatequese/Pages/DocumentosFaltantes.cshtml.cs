using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciamentoCatequese.Pages
{
    public class DocumentosFaltantesModel : PageModel
    {

        private readonly IGerenciamentoService _gerenciamentoService;

        public IEnumerable<Catequizando> _catequizandos { get; set; }
        public IEnumerable<Prazo> _prazos { get; set; }
        public IEnumerable<Turma> _turmas { get; set; }
        public IEnumerable<DocumentoFaltante> _documentos { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }


        [BindProperty]
        public RegistroDocumentosFaltantesRequisicao _registroDocumentosFaltantesRequisicao { get; set; }

        public DocumentosFaltantesModel(IGerenciamentoService gerenciamentoService)
        {
            _gerenciamentoService = gerenciamentoService;
        }

        public async Task<IActionResult> OnGet()
        {
            if (Id == 0)
            {
                _catequizandos = await _gerenciamentoService.ListarCatequizandos();
                _prazos = await _gerenciamentoService.ListarPrazos();
                _turmas = await _gerenciamentoService.ListarTurmas();
                _documentos = await _gerenciamentoService.ListarDocumentos();

            }
            else
            {
                _catequizandos = await _gerenciamentoService.ListarCatequizandos();
                _prazos = await _gerenciamentoService.ListarPrazos();
                _turmas = await _gerenciamentoService.ListarTurmas();
                _documentos = await _gerenciamentoService.ListarDocumentos();
                _registroDocumentosFaltantesRequisicao = await _gerenciamentoService.PesquisarRegistroCatequizando(Id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Id == 0)
            {
                _registroDocumentosFaltantesRequisicao.TelefoneResponsavelFixo = _registroDocumentosFaltantesRequisicao.TelefoneResponsavelFixo?.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                _registroDocumentosFaltantesRequisicao.TelefoneResponsavel = _registroDocumentosFaltantesRequisicao.TelefoneResponsavel?.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                await _gerenciamentoService.Registar(_registroDocumentosFaltantesRequisicao);

            }
            else
            {
                await _gerenciamentoService.AlterarRegistro(_registroDocumentosFaltantesRequisicao, Id);
            }
            return RedirectToPage("Index");
        }


    }
}
