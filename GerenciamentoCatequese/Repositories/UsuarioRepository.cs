using Dapper;
using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GerenciamentoCatequese.Repositories
{
    public class UsuarioRepository : IUsuarioService
    {

        private readonly IConfiguration _configuration;
        private ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(IConfiguration configuration, ILogger<UsuarioRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<UsuarioModel> LoginUsuario(string NomeLogin, string Senha)
        {
            try
            {
                var conexao = _configuration.GetConnectionString("Default");

                using var connection = new SqlConnection(conexao);


                var p = new DynamicParameters();
                p.Add("@NomeLogin", NomeLogin);
                p.Add("@Senha",Senha);

                 var retorno = await connection.QueryFirstOrDefaultAsync<UsuarioModel>(
                    "dbo.GetLogin",
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
