using AutoMapper;
using Contactos.Application.Dtos;
using Contactos.Domain;

namespace Contactos.Application.Mappings
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contacto, ContactDto>();

            CreateMap<CreateContactDto, Contacto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateContactDto, Contacto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
