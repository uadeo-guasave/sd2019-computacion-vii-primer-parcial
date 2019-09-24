using Microsoft.EntityFrameworkCore;

namespace practica04.Models
{
    public class SqliteDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Definir la conexion
            optionsBuilder.UseSqlite("Data source=Db/Users.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir las tablas
            modelBuilder.Entity<User>(u => {
                u.ToTable("users");
                u.Property(p => p.Id).HasColumnName("id");
                u.Property(p => p.Name).HasColumnName("name");
                u.Property(p => p.Password).HasColumnName("password");
                u.Property(p => p.FirstName).HasColumnName("first_name");
                u.Property(p => p.LastName).HasColumnName("last_name");
                u.Property(p => p.Email).HasColumnName("email");
                u.Property(p => p.RememberToken).HasColumnName("remember_token");
                u.Property(p => p.Status).HasColumnName("status");

                u.HasIndex(p => p.Name).IsUnique();
                u.HasIndex(p => p.Email).IsUnique();

                u.Property(p=>p.RememberToken).HasDefaultValue(null);
                
            });
            
        }

        public DbSet<User> Users { get; set; }
    }
}