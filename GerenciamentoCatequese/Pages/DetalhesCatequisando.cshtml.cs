using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciamentoCatequese.Pages
{
   
    public class DetalhesCatequisandoModel : PageModel
    {
        [BindProperty]
        public Catequisando _catequisando { get; set; } = new();

        public IEnumerable<ResponsavelCatequisando> _responsaveisCatequisando = Enumerable.Empty<ResponsavelCatequisando>();
        public IEnumerable<DocumentosEntregues> _documentos { get; set; } = Enumerable.Empty<DocumentosEntregues>();
        public DadosPagamento _pagamentos { get; set; } = new();

        [BindProperty]
        public string _ObservacoesGerais { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public int IdCatequisandoDetalhes { get; set; } = new();

        private readonly IGerenciamentoService _gerenciamento;

        public DetalhesCatequisandoModel(IGerenciamentoService gerenciamento)
        {
            _gerenciamento = gerenciamento;
        }

        public async Task<IActionResult> OnGet()
        {
            if (IdCatequisandoDetalhes != 0)
            {
                _catequisando = await _gerenciamento.PesquisaCatequisando(IdCatequisandoDetalhes);
                _responsaveisCatequisando = await _gerenciamento.ListarResponsaveisCatequisando(IdCatequisandoDetalhes);
                _ObservacoesGerais = await _gerenciamento.ListarObservacoes(IdCatequisandoDetalhes);
                _documentos = await _gerenciamento.ListarDocumentosEntregues(IdCatequisandoDetalhes);
                _pagamentos = await _gerenciamento.ListarDadosPagamento(IdCatequisandoDetalhes);
            }

            return Page();
        }
    }
}
