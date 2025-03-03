using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace GerenciamentoCatequese.Pages
{
    public class CatequisandoModel : PageModel
    {
        [BindProperty]
        public Catequisando _catequisando { get; set; }

        [BindProperty]
        public Pagamento _pagamento { get; set; }
        [BindProperty]
        public List<DocumentosEntregues> Documentos { get; set; } = new();

        public IEnumerable<Turma> _turmas { get; set; }
        public IEnumerable<Documento> _documentos { get; set; }



        private readonly IGerenciamentoService _gerenciamento;

        public CatequisandoModel(IGerenciamentoService gerenciamento)
        {
            _gerenciamento = gerenciamento;
        }

        public async Task<IActionResult> OnGet()
        {
            _turmas = await _gerenciamento.ListarTurmas();
            _documentos = await _gerenciamento.ListarDocumentos();
            return Page();
        }

        public IActionResult OnPostSalvarDocumentos([FromBody] SalvarDocumentosRequest request)
        {
            if (request == null || request.Documentos == null || request.Documentos.Count == 0)
            {
                return StatusCode(400, "Nenhum documento recebido.");
            }

            // Simulação de salvamento no banco de dados
            foreach (var doc in request.Documentos)
            {
                Console.WriteLine($"Documento ID: {doc.IdTipoDocumento}, Entregue: {doc.Entregue}, Local: {doc.LocalDocumento}");
            }

            if (request.Pagamento != null)
            {
                Console.WriteLine($"Pagamento - Tipo: {request.Pagamento.IdTipoPagamento}, " +
                                  $"Responsável: {request.Pagamento.NomeResponsavelPagamento}, " +
                                  $"Data: {request.Pagamento.DataPagamento}");
            }

            // Retorna um código 200 com a mensagem de sucesso
            return StatusCode(200, "Dados salvos com sucesso.");
        }

        public IActionResult OnPostSalvarDadosPessoais()
        {
            var retorno = _catequisando;
            return new JsonResult(new { success = true, message = "Step 1 processado com sucesso!" });
        }

    }
}

