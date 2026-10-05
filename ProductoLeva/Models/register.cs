using System.ComponentModel.DataAnnotations;

namespace ProductoLeva.Models
{
    public class register
    {
         public string nombre { get; set; }
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; } = string.Empty;
        public string telefono { get; set; }

    }
}
