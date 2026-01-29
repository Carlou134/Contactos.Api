namespace Contactos.Domain.Interfaces
{
    public interface IContactoRepository
    {
        Task<IReadOnlyCollection<Contacto>> listContactos();
        Task<bool> CreateContacto(Contacto contacto);
        Task<bool> UpdateContacto(Contacto contacto);
        Task<bool> DeleteContacto(int id);
        Task<Contacto?> GetContactoById(int id);
    }
}
