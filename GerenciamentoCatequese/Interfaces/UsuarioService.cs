using GerenciamentoCatequese.Models;

namespace GerenciamentoCatequese.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioModel> LoginUsuario(string NomeLogin, string Senha);
    }
}
