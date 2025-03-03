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

        public async Task <IEnumerable<Catequisando>> PesquisaCatequisando()
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);

                var p = new DynamicParameters();

                var retorno = await connection.QueryAsync<Catequisando>(
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

        





    }
}
