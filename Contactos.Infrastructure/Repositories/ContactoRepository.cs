using Contactos.Domain;
using Contactos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Contactos.Infrastructure.Repositories
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly ContactoContext _context;
        private readonly ILogger<ContactoRepository> _logger;

        public ContactoRepository(ContactoContext context, ILogger<ContactoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<Contacto>> listContactos()
        {
            try
            {
                return await _context.Contacto.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consulting the order in database");
                throw;
            }
        }

        public async Task<bool> CreateContacto(Contacto contacto)
        {
            try
            {
                _context.Contacto.Add(contacto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating the contact in database");
                throw;
            }
        }

        public async Task<Contacto?> GetContactoById(int id)
        {
            try
            {
                return await _context.Contacto.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading the contact from database");
                throw;
            }
        }

        public async Task<bool> UpdateContacto(Contacto contacto)
        {
            try
            {
                _context.Update(contacto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating the contact");
                throw;
            }
        }

        public async Task<bool> DeleteContacto(int id)
        {
            try
            {
                var contacto = await GetContactoById(id);

                if (contacto != null)
                {
                    _context.Remove(contacto);
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating the contact in the database");
                throw;
            }
        }
    }
}
