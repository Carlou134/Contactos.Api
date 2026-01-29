using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contactos.Infrastructure.Configurations
{
    public class ContactosConfiguration : IEntityTypeConfiguration<Contactos.Domain.Contactos>
    {
        public void Configure(EntityTypeBuilder<Contactos.Domain.Contactos> builder)
        {
            builder.ToTable("Contactos");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nombre).IsRequired();
            builder.Property(x => x.Teléfono).IsRequired();
        }
    }
}
