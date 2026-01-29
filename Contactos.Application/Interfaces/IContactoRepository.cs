using Contactos.Application.Dtos;

namespace Contactos.Domain.Interfaces
{
    public interface IContactoRepository
    {
        Task<IReadOnlyCollection<ContactDto>> listContactos();
        Task<bool> CreateContacto(Contacto contacto);
        Task<bool> UpdateContacto(Contacto contacto);
        Task<bool> DeleteContacto(int id);
        Task<Contacto?> GetContactoById(int id);
    }
}
