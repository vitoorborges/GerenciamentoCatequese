﻿namespace GerenciamentoCatequese.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string? NomeUsuario { get; set;}
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public int IdPerfil { get; set; }
        public int IdTurma { get; set; }


    }
}
