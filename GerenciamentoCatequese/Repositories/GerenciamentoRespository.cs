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

        public async Task <IEnumerable<RegistroDocumentosFaltantesTabela>> PesquisaRegistros()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<RegistroDocumentosFaltantesTabela>(
                   "dbo.PesquisaRegistro",
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

        public async Task<IEnumerable<Catequizando>> ListarCatequizandos()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<Catequizando>(
                   "dbo.ListarCatequizando",
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

        public async Task<IEnumerable<Prazo>> ListarPrazos()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<Prazo>(
                   "dbo.ListarPrazo",
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

        public async Task<IEnumerable<DocumentoFaltante>> ListarDocumentos()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<DocumentoFaltante>(
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

        public async Task Registar( RegistroDocumentosFaltantesRequisicao registro)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@NomeCatequisando", registro.NomeCatequizando);
                p.Add("@NomeResponsavel", registro.NomeResponsavel);
                p.Add("@TelefoneResponsavel", registro.TelefoneResponsavel);
                p.Add("@IdTurma", registro.IdTurma);
                p.Add("@TelefoneResponsavelFixo", registro.TelefoneResponsavelFixo);
                p.Add("@IdPrazoDocumentoFaltante", registro.IdPrazoDocumentoFaltante);
                p.Add("@IdDocumentoFaltante", registro.IdDocumentoFaltante);


                var retorno = await connection.QueryAsync(
                   "dbo.GravarDadosFaltantes",
                   p,
                   commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        public async Task AlterarRegistro(RegistroDocumentosFaltantesRequisicao registro, int idCatequisando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequisando", idCatequisando);
                p.Add("@NomeCatequisando", registro.NomeCatequizando);
                p.Add("@NomeResponsavel", registro.NomeResponsavel);
                p.Add("@TelefoneResponsavel", registro.TelefoneResponsavel);
                p.Add("@IdTurma", registro.IdTurma);
                p.Add("@TelefoneResponsavelFixo", registro.TelefoneResponsavelFixo);
                p.Add("@IdPrazoDocumentoFaltante", registro.IdPrazoDocumentoFaltante);
                p.Add("@IdDocumentoFaltante", registro.IdDocumentoFaltante);


                var retorno = await connection.QueryAsync(
                   "dbo.AtualizarRegistro",
                   p,
                   commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao buscar os dados {ex.Message}");
                throw new Exception(ex.Message);
            }

        }

        public async Task<RegistroDocumentosFaltantesRequisicao> PesquisarRegistroCatequizando(int IdCatequizando)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();
                p.Add("@IdCatequizando", IdCatequizando);

                var retorno = await connection.QueryFirstOrDefaultAsync<RegistroDocumentosFaltantesRequisicao>(
                   "dbo.PesquisarRegistroCatequizando",
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



    }
}
