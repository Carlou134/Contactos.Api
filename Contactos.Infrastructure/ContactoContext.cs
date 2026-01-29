using Contactos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Contactos.Infrastructure
{
    public class ContactoContext : DbContext
    {
        public ContactoContext(DbContextOptions options) : base(options){}

        public DbSet<Contacto> Contacto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
