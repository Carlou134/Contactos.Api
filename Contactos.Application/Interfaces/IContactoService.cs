using Contactos.Application.Dtos;

namespace Contactos.Application.Interfaces
{
    public interface IContactoService
    {
        Task<IEnumerable<ContactDto>> GetContacts();
        Task<bool> CreateContact(CreateContactDto request);
        Task<ContactDto?> GetContact(int id);
        Task<bool> UpdateContact(int id, UpdateContactDto request);
        Task<bool> DeleteContact(int id);
    }
}
