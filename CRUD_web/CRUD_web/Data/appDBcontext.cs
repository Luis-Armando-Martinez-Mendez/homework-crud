using Microsoft.EntityFrameworkCore;
using CRUD_web.Models;

namespace CRUD_web.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext>options) : base(options)
        {
        }

        public DbSet<Cliente>CLIENTES{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(tab => {
                tab.HasKey(colum => colum.Idcliente);

                tab.Property(colum => colum.Idcliente)
                .UseIdentityColumn();


                tab.Property(colum => colum.Nombre).HasMaxLength(60);
                tab.Property(colum => colum.Email).HasMaxLength(30);

            });
        }

    }
}
