namespace Contactos.Domain
{
    public class Contactos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Teléfono { get; set; } = string.Empty;
    }
}
