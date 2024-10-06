﻿using System.ComponentModel.DataAnnotations;
using VodjenjeKaficaCSHARP.Validations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record DobavljacDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv dobavljaca obavezan")] string? Naziv,
        [Required(ErrorMessage = "Grad dobavljaca obavezan")] string? Grad,
        [Required(ErrorMessage = "Adresa dobavljaca obavezna")] string? Adresa,
        [OibValidator]
        [Required(ErrorMessage = "Oib dobavljaca obavezan")] string? Oib
        ); 
}
