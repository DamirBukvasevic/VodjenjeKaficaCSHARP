﻿using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record OperaterDTO(
        [Required(ErrorMessage = "Email je obavezan.")]
            string? email,
        [Required(ErrorMessage = "Lozinka je obavezna.")]
            string? password);
}