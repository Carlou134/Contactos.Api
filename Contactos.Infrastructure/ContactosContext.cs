using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Contactos.Infrastructure
{
    public class ContactosContext : DbContext
    {
        public ContactosContext(DbContextOptions options) : base(options){}

        public DbSet<Contactos.Domain.Contactos> Contactos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
