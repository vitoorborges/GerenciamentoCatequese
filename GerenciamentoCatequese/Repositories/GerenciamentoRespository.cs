using Dapper;
using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GerenciamentoCatequese.Repositories
{
    public class GerenciamentoRespository : IGerenciamentoService
    {
        private readonly IConfiguration _configuration;
        private ILogger<UsuarioRepository> _logger;

        public GerenciamentoRespository(IConfiguration configuration, ILogger<UsuarioRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IEnumerable<Catequisando>> ListaCatequisandos(int IdPerfil, int IdTurma, int AnoCatequese)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("IdPerfil", IdPerfil);
                p.Add("Idturma", IdTurma);
                p.Add("AnoCatequese", AnoCatequese);

                var retorno = await connection.QueryAsync<Catequisando>(
                   "dbo.UspListaCatequisandos",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Catequisando> PesquisaCatequisando(int IdCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", IdCatequisando);

                var retorno = await connection.QueryFirstOrDefaultAsync<Catequisando>(
                   "dbo.PesquisaCatequisando",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Turma>> ListarTurmas()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<Turma>(
                   "dbo.ListarTurmas",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Documento>> ListarDocumentos()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<Documento>(
                   "dbo.ListarDocumentos",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TipoParentesco>> ListarParentesco()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<TipoParentesco>(
                   "dbo.ListarTipoParentesco",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GravarDadosPessoais(Catequisando catequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@NomeCatequisando", catequisando.NomeCatequisando);
                p.Add("@IdTurma", catequisando.IdTurma);
                p.Add("@DataNascimento", catequisando.DataNascimento);
                p.Add("@UFNaturalidade", catequisando.UFNaturalidade);
                p.Add("@MunicipioNaturalidade", catequisando.MunicipioNaturalidade);
                p.Add("@Batizado", catequisando.Batizado);
                p.Add("@DataBatismo", catequisando.DataBatismo);
                p.Add("@UFBatismo", catequisando.UFBatismo);
                p.Add("@MunicipioBatismo", catequisando.MunicipioBatismo);
                p.Add("@ParoquiBatismo", catequisando.ParoquiBatismo);
                p.Add("@Eucaristia", catequisando.Eucaristia);
                p.Add("@DataEucaristia", catequisando.DataEucaristia);
                p.Add("@UFEucatistia", catequisando.UFEucatistia);
                p.Add("@MunicipioEucaristia", catequisando.MunicipioEucaristia);
                p.Add("@ParoquiaEucaristia", catequisando.ParoquiaEucaristia);
                p.Add("@Pastoral", catequisando.Pastoral);
                p.Add("@DescricaoPastoral", catequisando.DescricaoPastoral);
                p.Add("@CepEndereco", catequisando.CepEndereco);
                p.Add("@UFEndereco", catequisando.UFEndereco);
                p.Add("@LogradouroEndereco", catequisando.LogradouroEndereco);
                p.Add("@BairroEndereco", catequisando.BairroEndereco);
                p.Add("@CidadeEndereco", catequisando.CidadeEndereco);
                p.Add("@NumeroEndereco", catequisando.NumeroEndereco);
                p.Add("@ComplementoEndereco", catequisando.ComplementoEndereco);
                p.Add("@Email", catequisando.Email);
                p.Add("@TelefoneResidencial", catequisando.TelefoneResidencial);
                p.Add("@TelefoneCelular", catequisando.TelefoneCelular);

                var retorno = await connection.QueryFirstOrDefaultAsync<int>(
                    "dbo.UspCadastroCatequisando",
                    p,
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao gravar os dados: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GravarDadosResponsavel(ResponsavelCatequisando _responsavelCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", _responsavelCatequisando.IdCatequisando);
                p.Add("@IdTipoParentesco", _responsavelCatequisando.IdTipoParentesco);
                p.Add("@NomeResponsavel", _responsavelCatequisando.NomeResponsavel);
                p.Add("@DataNascimentoResponsavel", _responsavelCatequisando.DataNascimentoResponsavel);
                p.Add("@Religiao", _responsavelCatequisando.Religiao);
                p.Add("@ProfissaoResponsavel", _responsavelCatequisando.ProfissaoResponsavel);
                p.Add("@DataCasamento", _responsavelCatequisando.DataCasamento);
                p.Add("@Batismo", _responsavelCatequisando.Batismo);
                p.Add("@Eucaristia", _responsavelCatequisando.Eucaristia);
                p.Add("@Crisma", _responsavelCatequisando.Crisma);
                p.Add("@Matrimonio", _responsavelCatequisando.Matrimonio);
                p.Add("@OutraPastoral", _responsavelCatequisando.OutraPastoral);
                p.Add("@DescricaoOutraPastoral", _responsavelCatequisando.DescricaoOutraPastoral);
                p.Add("@Dizimista", _responsavelCatequisando.Dizimista);
                p.Add("@TelefoneCelular", _responsavelCatequisando.TelefoneCelular);

                // Executa a procedure e retorna o ID do responsável inserido
                var retorno = await connection.QueryFirstOrDefaultAsync<int>(
                    "dbo.UspCadastroResponsavel",
                    p,
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao gravar os dados do responsável: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GravarPagamentoTaxa(PagamentoTaxa pagamentoTaxa)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", pagamentoTaxa.IdCatequisando);
                p.Add("@IdTurma", pagamentoTaxa.IdTurma);
                p.Add("@Parcela", pagamentoTaxa.Parcela);
                p.Add("@DataPagamento", pagamentoTaxa.DataPagamento);
                p.Add("@ValorPagamento", pagamentoTaxa.ValorPagamento);
                p.Add("@NomeResponsavel", pagamentoTaxa.NomeResponsavel);
                // Executa a procedure e retorna o ID do responsável inserido
                var retorno = await connection.QueryFirstOrDefaultAsync<int>(
                    "dbo.UspGravaPagamentoTaxa",
                    p,
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao gravar os dados do pagamento: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GravarDocumentoEntregue(DocumentosEntregues documentosEntregues, int idCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdTipoDocumento", documentosEntregues.IdTipoDocumento);
                p.Add("@IdCatequisando", idCatequisando);
                p.Add("@Entregue", documentosEntregues.Entregue);
                p.Add("@LocalDocumento", documentosEntregues.LocalDocumento);



                // Executa a procedure e retorna o ID do responsável inserido
                var retorno = await connection.QueryFirstOrDefaultAsync<int>(
                    "dbo.UspGravarDocumentoEntregue",
                    p,
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao gravar os dados do responsável: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GravarDadosPagamento(DadosPagamento dadosPagamento, int IdCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdTipoPagamento", dadosPagamento.IdTipoPagamento);
                p.Add("@IdCatequisando", IdCatequisando);
                p.Add("@NomeResponsavelPagamento", dadosPagamento.NomeResponsavelPagamento);
                p.Add("@DataPagamento", dadosPagamento.DataPagamento);


                // Executa a procedure e retorna o ID do responsável inserido
                var retorno = await connection.QueryFirstOrDefaultAsync<int>(
                    "dbo.UspGravaPagamento",
                    p,
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao gravar os dados do responsável: {ex.Message}");
                throw;
            }
        }

        public async Task<int> AtualizarDadosCatequisando(Catequisando catequisando, int IdCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", IdCatequisando);
                p.Add("@NomeCatequisando", catequisando.NomeCatequisando);
                p.Add("@IdTurma", catequisando.IdTurma);
                p.Add("@DataNascimento", catequisando.DataNascimento);
                p.Add("@UFNaturalidade", catequisando.UFNaturalidade);
                p.Add("@MunicipioNaturalidade", catequisando.MunicipioNaturalidade);
                p.Add("@Batizado", catequisando.Batizado);
                p.Add("@DataBatismo", catequisando.DataBatismo);
                p.Add("@UFBatismo", catequisando.UFBatismo);
                p.Add("@MunicipioBatismo", catequisando.MunicipioBatismo);
                p.Add("@ParoquiBatismo", catequisando.ParoquiBatismo);
                p.Add("@Eucaristia", catequisando.Eucaristia);
                p.Add("@DataEucaristia", catequisando.DataEucaristia);
                p.Add("@UFEucatistia", catequisando.UFEucatistia);
                p.Add("@MunicipioEucaristia", catequisando.MunicipioEucaristia);
                p.Add("@ParoquiaEucaristia", catequisando.ParoquiaEucaristia);
                p.Add("@Pastoral", catequisando.Pastoral);
                p.Add("@DescricaoPastoral", catequisando.DescricaoPastoral);
                p.Add("@CepEndereco", catequisando.CepEndereco);
                p.Add("@UFEndereco", catequisando.UFEndereco);
                p.Add("@LogradouroEndereco", catequisando.LogradouroEndereco);
                p.Add("@BairroEndereco", catequisando.BairroEndereco);
                p.Add("@CidadeEndereco", catequisando.CidadeEndereco);
                p.Add("@NumeroEndereco", catequisando.NumeroEndereco);
                p.Add("@ComplementoEndereco", catequisando.ComplementoEndereco);
                p.Add("@Email", catequisando.Email);
                p.Add("@TelefoneResidencial", catequisando.TelefoneResidencial);
                p.Add("@TelefoneCelular", catequisando.TelefoneCelular);

                // Executa a procedure e retorna o ID atualizado
                var retorno = await connection.QueryFirstOrDefaultAsync<int>(
                    "dbo.UspAtualizarCatequisando",
                    p,
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar os dados do catequisando: {ex.Message}");
                throw;
            }
        }

        public async Task<int> AtualizarDadosResponsavel(ResponsavelCatequisando responsavel, int IdResponsavelCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdResponsavelCatequisando", IdResponsavelCatequisando);
                p.Add("@IdTipoParentesco", responsavel.IdTipoParentesco);
                p.Add("@NomeResponsavel", responsavel.NomeResponsavel);
                p.Add("@DataNascimentoResponsavel", responsavel.DataNascimentoResponsavel);
                p.Add("@Religiao", responsavel.Religiao);
                p.Add("@ProfissaoResponsavel", responsavel.ProfissaoResponsavel);
                p.Add("@DataCasamento", responsavel.DataCasamento);
                p.Add("@Batismo", responsavel.Batismo);
                p.Add("@Eucaristia", responsavel.Eucaristia);
                p.Add("@Crisma", responsavel.Crisma);
                p.Add("@Matrimonio", responsavel.Matrimonio);
                p.Add("@OutraPastoral", responsavel.OutraPastoral);
                p.Add("@DescricaoOutraPastoral", responsavel.DescricaoOutraPastoral);
                p.Add("@Dizimista", responsavel.Dizimista);
                p.Add("@TelefoneCelular", responsavel.TelefoneCelular);

                // Executa a procedure e retorna o ID atualizado
                var retorno = await connection.QueryFirstOrDefaultAsync<int>(
                    "dbo.UspAtualizarResponsavel",
                    p,
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar os dados do responsavel: {ex.Message}");
                throw;
            }
        }


        public async Task<IEnumerable<ResponsavelCatequisando>> ListarResponsaveisCatequisando(int IdCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", IdCatequisando);

                var retorno = await connection.QueryAsync<ResponsavelCatequisando>(
                   "dbo.UspPesquisaResponsaveis",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DocumentosEntregues>> ListarDocumentosEntregues(int IdCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", IdCatequisando);

                var retorno = await connection.QueryAsync<DocumentosEntregues>(
                   "dbo.UpsListarDocumentosEntregues",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RegistroPagamentosTaxa>> ListarRegistrosPagamentosTaxa(int IdCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", IdCatequisando);

                var retorno = await connection.QueryAsync<RegistroPagamentosTaxa>(
                   "dbo.UspListarPagamentosTaxa",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<DadosPagamento> ListarDadosPagamento(int IdCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", IdCatequisando);

                var retorno = await connection.QueryFirstOrDefaultAsync<DadosPagamento>(
                   "dbo.UspListarDadosPagamento",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }


        public async Task<IEnumerable<CatequisandoRelatorio>> GerarRelatorioCompleto(int IdTurma)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdTurma", IdTurma);

                var retorno = await connection.QueryAsync<CatequisandoRelatorio>(
                   "dbo.UpsGerarRelatorioCatequisandoCompleto",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RelatorioFrequencia>> GerarRelatorioFrequencia(int IdTurma)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdTurma", IdTurma);

                var retorno = await connection.QueryAsync<RelatorioFrequencia>(
                   "dbo.UspGerarRelatorioFrequencia",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RelatorioFrequencia>> GerarRelatorioFrequenciaCrismaAdulto(int IdTurma)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdTurma", IdTurma);

                var retorno = await connection.QueryAsync<RelatorioFrequencia>(
                   "dbo.UspGerarRelatorioFrequenciaCrismaAdulto",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RelatorioFrequencia>> GravarObservacoes(int IdCatequisando, string ObservacoesGerais)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", IdCatequisando);
                p.Add("@ObservacoesGerais", ObservacoesGerais);

                var retorno = await connection.QueryAsync<RelatorioFrequencia>(
                   "dbo.UspCadastrarObservacoes",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> ListarObservacoes(int IdCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", IdCatequisando);

                var retorno = await connection.QueryFirstOrDefaultAsync<string>(
                   "dbo.UspBuscarObservacoes",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RelatorioResponsaveis>> GerarRelatorioResponsaveis(int IdTurma)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdTurma", IdTurma);

                var retorno = await connection.QueryAsync<RelatorioResponsaveis>(
                   "dbo.UspGerarRelatorioResponsaveis",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task ExcluirCadastro(int IdCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", IdCatequisando);

                await connection.QueryAsync(
                   "dbo.UspExcluirCadastro",
                   p,
                   commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> InserirCatequista(Catequista catequista)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);
                int batismo = 0;
                int eucaristia = 0;
                int crisma = 0;
                int matrimonio = 0;

                foreach (var item in catequista.Sacramentos)
                {
                    switch (item.IdSacramento)
                    {
                        case 1:
                            batismo = 1;
                            break;
                        case 2:
                            eucaristia = 1;
                            break;
                        case 3:
                            crisma = 1;
                            break;
                        case 4:
                            matrimonio = 1;
                            break;
                    }
                }

                var p = new DynamicParameters();
                p.Add("@IdTurma", catequista.IdTurma);
                p.Add("@IdPerfil", catequista.IdPerfil);
                p.Add("@NomeCatequista", catequista.NomeCatequista);
                p.Add("@DataNascimento", catequista.DataNascimento);
                p.Add("@Email", catequista.Email);
                p.Add("@Telefone", catequista.Telefone);
                p.Add("@EnderecoCompleto", catequista.Endereco);
                p.Add("@Trabalha", catequista.Trabalha);
                p.Add("@Profissao", catequista.Profissao);
                p.Add("@Disponibilidade", catequista.Disponibilidade);
                p.Add("@TamanhoCamiseta", catequista.TamanhoCamiseta);
                p.Add("@EstadoCivil", catequista.EstadoCivil);
                p.Add("@Pastoral", catequista.Pastoral);
                p.Add("@DescricaoPastoral", catequista.DescricaoPastoral);
                p.Add("@Batismo", batismo);
                p.Add("@Eucaristia", eucaristia);
                p.Add("@Crisma", crisma);
                p.Add("@Matrimonio", matrimonio);
                p.Add("@Foto", catequista.Foto);
                p.Add("@Senha", catequista.Senha);

               
                var id = await connection.ExecuteScalarAsync<int>(
                    "dbo.UspCadastroCatequista",
                    p,
                    commandType: CommandType.StoredProcedure);

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao inserir catequista: {ex.Message}");
                throw;
            }
        }

        public async Task<int> AtualizarCatequista(Catequista catequista, int idCatequista)
        {
            try
            {

                int batismo = 0;
                int eucaristia = 0;
                int crisma = 0;
                int matrimonio = 0;

                foreach (var item in catequista.Sacramentos)
                {
                    switch (item.IdSacramento)
                    {
                        case 1:
                            batismo = 1;
                            break;
                        case 2:
                            eucaristia = 1;
                            break;
                        case 3:
                            crisma = 1;
                            break;
                        case 4:
                            matrimonio = 1;
                            break;
                    }
                }

                var conexao = _configuration.GetConnectionString("Default");
                using var connection = new SqlConnection(conexao);
                var p = new DynamicParameters();
                p.Add("@IdCatequista", idCatequista);
                p.Add("@IdTurma", catequista.IdTurma);
                p.Add("@IdPerfil", catequista.IdPerfil);
                p.Add("@NomeCatequista", catequista.NomeCatequista);
                p.Add("@DataNascimento", catequista.DataNascimento);
                p.Add("@Email", catequista.Email);
                p.Add("@Telefone", catequista.Telefone);
                p.Add("@EnderecoCompleto", catequista.Endereco);
                p.Add("@Trabalha", catequista.Trabalha);
                p.Add("@Profissao", catequista.Profissao);
                p.Add("@Disponibilidade", catequista.Disponibilidade);
                p.Add("@TamanhoCamiseta", catequista.TamanhoCamiseta);
                p.Add("@EstadoCivil", catequista.EstadoCivil);
                p.Add("@Pastoral", catequista.Pastoral);
                p.Add("@DescricaoPastoral", catequista.DescricaoPastoral);
                p.Add("@Batismo", batismo);
                p.Add("@Eucaristia", eucaristia);
                p.Add("@Crisma", crisma);
                p.Add("@Matrimonio", matrimonio);
                p.Add("@Foto", catequista.Foto);
                p.Add("@Senha", catequista.Senha);
                var id = await connection.ExecuteScalarAsync<int>(
                    "dbo.UspAtualizaCatequista",
                    p,
                    commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar catequista: {ex.Message}");
                throw;
            }
        }


        public async Task<IEnumerable<Catequista>> ListarCatequistas()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<Catequista>(
                   "dbo.UspPesquisaCatequistas",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<RelatorioPagamentoTaxa>> GerarRelatorioPagamentoTaxa()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<RelatorioPagamentoTaxa>(
                   "dbo.GerarRelatorioPagamentoTaxa",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RelatorioFrequenciaLancada>> GerarRelatorioFrequenciaLancada()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");
                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<RelatorioFrequenciaLancada>(
                   "dbo.uspListarFrequenciasLancadas",
                   p,
                   commandType: CommandType.StoredProcedure);

                return retorno!;
            }
            catch (Exception ex)
            { 
                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Catequista> PesquisaCatequista(int IdCatequista) 
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequista", IdCatequista);

                var retorno = await connection.QueryFirstOrDefaultAsync<Catequista>(
                    "dbo.UspPesquisaCatequista",
                    p,
                    commandType: CommandType.StoredProcedure);

                return retorno;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao pesquisar um catequista {ex.Message}");
                throw new Exception(ex.Message);
            }
            
        }

        public async Task DeletarPagamentoTaxa(int IdPagamentoTaxa)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdPagamentoTaxa", IdPagamentoTaxa);

                await connection.QueryAsync(
                   "dbo.uspDeletarPagamentoTaxa",
                   p,
                   commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao deletar o pagamento {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task RegistrarFrequenciaCatequisando(int IdTurma, DateTime DataFrequencia, DataTable frequenciaCatequisandos)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdTurma", IdTurma);
                p.Add("@DataFrequencia", DataFrequencia);
                p.Add("@ListaFrequencia", frequenciaCatequisandos.AsTableValuedParameter("dbo.FrequenciaCatequisandoType"));

                await connection.QueryAsync(
                   "dbo.uspRegistraFrequenciaCatequisando",
                   p,
                   commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao registrar a frequência: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
