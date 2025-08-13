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
        public Catequisando _catequisando { get; set; } = new();
        [BindProperty]
        public List<DocumentosEntregues> Documentos { get; set; } = new();

        [BindProperty]
        public ResponsavelCatequisando _responsavelCatequisando{ get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int IdCatequisandoEditar { get; set; } = new();
        [BindProperty]
        public string _ObservacoesGerais { get; set; }
        [BindProperty]
        public int IdCatequisandoObservacao {  get; set; } = new();

        public IEnumerable<Turma> _turmas { get; set; } = Enumerable.Empty<Turma>();
        public IEnumerable<Documento> _documentos { get; set; } = Enumerable.Empty<Documento>();
        public IEnumerable<TipoParentesco> _tipoParentescos { get; set; } = Enumerable.Empty<TipoParentesco>();
        public IEnumerable<ResponsavelCatequisando> _responsaveisCatequisando = Enumerable.Empty<ResponsavelCatequisando>();




        private readonly IGerenciamentoService _gerenciamento;

        public CatequisandoModel(IGerenciamentoService gerenciamento)
        {
            _gerenciamento = gerenciamento;
        }

        public async Task<IActionResult> OnGet()
        {
            
            _turmas = await _gerenciamento.ListarTurmas();
            _documentos = await _gerenciamento.ListarDocumentos();
            _tipoParentescos = await _gerenciamento.ListarParentesco();

            if(IdCatequisandoEditar != 0)
            {
                _catequisando = await _gerenciamento.PesquisaCatequisando(IdCatequisandoEditar);
                _responsaveisCatequisando = await _gerenciamento.ListarResponsaveisCatequisando(IdCatequisandoEditar);
                _ObservacoesGerais = await _gerenciamento.ListarObservacoes(IdCatequisandoEditar);
            }

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
                var teste = request.IdCatequisando;
                _gerenciamento.GravarDocumentoEntregue(doc,request.IdCatequisando);
            }

            if (request.Pagamento != null)
            {
                _gerenciamento.GravarDadosPagamento(request.Pagamento, request.IdCatequisando);
            }

            // Retorna um código 200 com a mensagem de sucesso
            return StatusCode(200, "Dados salvos com sucesso.");
        }

        public async Task<IActionResult> OnPostSalvarDadosPessoais()
        {
            int IdCatequisandoResponsaveis = 0;

            if (IdCatequisandoEditar == 0) {

                IdCatequisandoResponsaveis =  await _gerenciamento.GravarDadosPessoais(_catequisando);
                IdCatequisandoEditar = IdCatequisandoResponsaveis;

            }
            else
            {
                IdCatequisandoResponsaveis = await _gerenciamento.AtualizarDadosCatequisando(_catequisando, IdCatequisandoEditar);
            }
            //int IdCatequisandoResponsaveis = 1;
            return new JsonResult(new { success = true, message = $"Step 1 processado com sucesso!", idcatequisandoresponsavel = IdCatequisandoResponsaveis });
        }

        public async Task<IActionResult> OnPostAdicionarResponsavel()
        {
            var retorno = 0;
            // Salva os dados no banco
            if (_responsavelCatequisando.IdResponsavelCatequisando == 0)
                retorno = await _gerenciamento.GravarDadosResponsavel(_responsavelCatequisando);
            else
                retorno = await _gerenciamento.AtualizarDadosResponsavel(_responsavelCatequisando, _responsavelCatequisando.IdResponsavelCatequisando);

            if (retorno == null)
            {
                return new JsonResult(new { success = false, message = "Erro ao salvar os dados do responsável." });
            }

            switch (_responsavelCatequisando.IdTipoParentesco)
            {
                case 1:
                    _responsavelCatequisando.DescricaoParentesco = "Mãe"; 
                        break;
                case 2:
                    _responsavelCatequisando.DescricaoParentesco = "Pai";
                    break;
                case 3:
                    _responsavelCatequisando.DescricaoParentesco = "Avó";
                    break;
                case 4:
                    _responsavelCatequisando.DescricaoParentesco = "Avô";
                    break;
                case 5:
                    _responsavelCatequisando.DescricaoParentesco = "Tio(a)";
                    break;
                default:
                    _responsavelCatequisando.DescricaoParentesco = "Não identificado";
                    break;
            }

            // Retorna os dados do responsável recém-adicionado para o frontend
            return new JsonResult(new
            {
                success = true,
                message = "Responsável cadastrado com sucesso!",
                responsavel = new
                {
                    NomeResponsavel = _responsavelCatequisando.NomeResponsavel,
                    IdTipoParentesco = _responsavelCatequisando.DescricaoParentesco,
                    TelefoneCelular = _responsavelCatequisando.TelefoneCelular,
                    IdResponsavelCatequisando = retorno
                },
                IdCatequisandoEditar = _responsavelCatequisando.IdCatequisando
            });
        }


        public async Task<IActionResult> OnGetBuscarDadosPagamento(int id)
        {          

            var documentos = await _gerenciamento.ListarDocumentosEntregues(id);

            var pagamento = await _gerenciamento.ListarDadosPagamento(id);

            return new JsonResult(new
            {
                documentos,
                pagamento
            });
        }

        public async Task<IActionResult> OnGetGetResponsavel(int id, int IdCatequisandoEditarGet)   
        {
            _responsaveisCatequisando = await _gerenciamento.ListarResponsaveisCatequisando(IdCatequisandoEditarGet);
            var responsavel = _responsaveisCatequisando.Where(x => x.IdResponsavelCatequisando == id).First();

            return new JsonResult(responsavel);
        }
        public async Task<IActionResult> OnPostGravarObservacoesReponsaveis()
        {
            await _gerenciamento.GravarObservacoes(IdCatequisandoObservacao, _ObservacoesGerais);
            return RedirectToPage("Index");
        }


    }
}

