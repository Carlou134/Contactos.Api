using Contactos.Application.Dtos;
using Contactos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contactos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoService _contactoService;

        public ContactoController(IContactoService contactoService)
        {
            _contactoService = contactoService;
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetContactos()
        {
            return Ok(await _contactoService.GetContacts());
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateContacto([FromBody] CreateContactDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _contactoService.CreateContact(request);

            return (result) ? NoContent() : NotFound();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateContacto(int id, [FromBody] UpdateContactDto request)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid contactId");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _contactoService.UpdateContact(id, request);

            return (result) ? NoContent() : NotFound();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid contactId");
            }

            var result = await _contactoService.DeleteContact(id);

            return (result) ? NoContent() : NotFound();
        }

        [HttpGet("list/{id}")]
        public async Task<ActionResult> GetContact(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid contactId");
            }

            var result = await _contactoService.GetContact(id);

            if (result == null)
            {
                return NotFound("The contact don't exists");
            }

            return Ok(result);
        }
    }
}
