using System.ComponentModel.DataAnnotations;

namespace TDDTestingMVC1.Models
{
    public class Cliente
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "La cédula debe tener 10 dígitos.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "La cédula solo puede contener números.")]
        public string Cedula { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Los apellidos solo pueden contener letras.")]
        public string Apellidos { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Los nombres solo pueden contener letras.")]
        public string Nombres { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(ClientValidation), "ValidarFechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El correo electrónico no es válido.")]
        public string Mail { get; set; }

        [Required]
        [RegularExpression(@"^09\d{7}$", ErrorMessage = "El teléfono debe tener 9 dígitos y comenzar con 09.")]
        public string Telefono { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public bool Estado { get; set; }
    }

    // Clase de validación personalizada para la fecha de nacimiento
    public class ClientValidation
    {
        public static ValidationResult ValidarFechaNacimiento(DateTime fechaNacimiento, ValidationContext context)
        {
            if (fechaNacimiento >= DateTime.Now)
            {
                return new ValidationResult("La fecha de nacimiento debe ser anterior a la fecha actual.");
            }
            return ValidationResult.Success;
        }
    }

}