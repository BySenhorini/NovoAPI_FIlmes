﻿using System.ComponentModel.DataAnnotations;

namespace api_filmes_senai1.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O e-mail é obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 10 caracteres e no máximo 60")]
        public string? Senha { get; set; }
    }
}



