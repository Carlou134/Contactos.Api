using AutoMapper;
using Contactos.Application.Dtos;
using Contactos.Application.Interfaces;
using Contactos.Domain;
using Contactos.Domain.Interfaces;

namespace Contactos.Application.Services
{
    public class ContactoService : IContactoService
    {
        private readonly IContactoRepository _repository;
        private readonly IMapper _mapper;

        public ContactoService(IContactoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        public async Task<IEnumerable<ContactDto>> GetContacts()
        {
            return await _repository.listContactos();
        }

        public async Task<bool> CreateContact(CreateContactDto request)
        {
            var newContacto = _mapper.Map<Contacto>(request);
            return await _repository.CreateContacto(newContacto);
        }

        public async Task<ContactDto?> GetContact(int id)
        {
            var product = await _repository.GetContactoById(id);

            if (product != null)
            {
                return _mapper.Map<ContactDto>(product);
            }

            return null;
        }

        public async Task<bool> UpdateContact(int id, UpdateContactDto request)
        {
            var contacto = await _repository.GetContactoById(id);

            if (contacto != null)
            {
                _mapper.Map(request, contacto);
                return await _repository.UpdateContacto(contacto);
            }

            return false;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contacto = await _repository.GetContactoById(id);

            if (contacto != null)
            {
                return await _repository.DeleteContacto(id);
            }

            return false;
        }

    }
}
