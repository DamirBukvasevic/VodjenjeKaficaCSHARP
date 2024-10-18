using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace VodjenjeKaficaCSHARP.Validations
{
    /// <summary>
    /// Provjerava valjanost OIB-a (Osobni identifikacijski broj) prema hrvatskom standardu.
    /// </summary>
    public class OibValidator : ValidationAttribute
    {
        /// <summary>
        /// Provjerava valjanost OIB-a.
        /// </summary>
        /// <param name="value">Vrijednost OIB-a koju treba provjeriti.</param>
        /// <param name="validationContext">Kontekst provjere valjanosti.</param>
        /// <returns>Rezultat provjere valjanosti.</returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            var oib = (string)value;
            if (oib.Length == 0)
            {
                return ValidationResult.Success;
            }
            return IsValidOIB(oib) ? ValidationResult.Success : new ValidationResult("OIB nije formalno valjan"); ;
        }

        // https://github.com/domagojpa/oib-validation/blob/main/CSharp/oib-validation.cs
        /// <summary>
        /// Provjerava valjanost OIB-a (Osobni identifikacijski broj) prema hrvatskom standardu.
        /// </summary>
        /// <param name="oib">OIB koji se provjerava</param>
        /// <returns>True ako je OIB valjan, inače False</returns>
        public static bool IsValidOIB(string oib)
        {
            if (string.IsNullOrEmpty(oib) || !Regex.IsMatch(oib, "^[0-9]{11}$"))
                return false;

            var oibSpan = oib.AsSpan();
            var a = 10;
            for (var i = 0; i < 10; i++)
            {
                a += int.Parse(oibSpan.Slice(i, 1));
                a %= 10;

                if (a == 0)
                    a = 10;

                a *= 2;
                a %= 11;
            }

            var kontrolni = 11 - a;

            if (kontrolni == 10)
                kontrolni = 0;

            return kontrolni == int.Parse(oibSpan.Slice(10, 1));
        }

    }
}