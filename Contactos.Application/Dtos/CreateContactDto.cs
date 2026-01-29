using System.ComponentModel.DataAnnotations;

namespace Contactos.Application.Dtos
{
    public class CreateContactDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;
    }
}
