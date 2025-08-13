using GerenciamentoCatequese.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace GerenciamentoCatequese.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<LoginModel> _logger;
        private readonly INotyfService _notificacao;
        public LoginModel(IUsuarioService usuarioService, ILogger<LoginModel> logger, INotyfService notificacao)
        {
            _usuarioService = usuarioService;
            this._logger = logger;
            _notificacao = notificacao;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string NomeLogin, string Senha)
        {
            try
            {
                var retorno = await _usuarioService.LoginUsuario(NomeLogin, Senha);
                if (retorno is null)
                {
                    _notificacao.Error("Credenciais inv�lidas");
                    return Page();
                }

                var iniciais = RetornaIniciais(retorno.NomeUsuario!);

                await CriarSessao(NomeLogin, retorno.NomeUsuario!,iniciais, false, retorno.IdPerfil, retorno.IdTurma);
                _notificacao.Success("Login realizado com sucesso");
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao realizar login{ex.Message}");
                throw;
            }
        }


        public async Task CriarSessao(string NomeLogin, string NomeCandidato, string Iniciais, bool PermanecerLogado, int IdPerfil, int IdTurma)
        {
            var claims = new List<Claim>
            {
                new Claim("NomeLogin", NomeLogin),
                new Claim("Iniciais", Iniciais),
                new Claim(ClaimTypes.Name, NomeCandidato),
                new Claim("IdPerfil", IdPerfil.ToString()),
                new Claim("IdTurma", IdTurma.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();
            authProperties.IsPersistent = PermanecerLogado;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Debug")
            {
                var tempoAutenticacaoPersistente = 30;

                if (tempoAutenticacaoPersistente > 0)
                {
                    authProperties.IsPersistent = true;
                    authProperties.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(tempoAutenticacaoPersistente);
                }

            }

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public string RetornaIniciais(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) return string.Empty;

            var palavras = nome.Split(' ')
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .ToArray();

            if (palavras.Length < 2) return string.Empty;

            return $"{palavras[0][0]}{palavras[1][0]}".ToUpper();
        }
    }
}
