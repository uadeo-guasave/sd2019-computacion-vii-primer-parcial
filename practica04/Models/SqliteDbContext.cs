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
                u.Property(p => p.RoleId).HasColumnName("role_id");

                u.HasIndex(p => p.Name).IsUnique();
                u.HasIndex(p => p.Email).IsUnique();

                u.Property(p=>p.RememberToken).HasDefaultValue(null);
                
                u.HasOne(r => r.Role).WithMany(p => p.Users);
            });

            modelBuilder.Entity<Role>(r => {
                r.ToTable("roles");
                r.Property(p => p.Id).HasColumnName("id");
                r.Property(p => p.Name).HasColumnName("name");

                r.HasIndex(p => p.Name).IsUnique();

                r.HasMany(u => u.Users).WithOne(p => p.Role);
                r.HasMany(pm => pm.Users).WithOne(p => p.Role);
            });

            modelBuilder.Entity<Permission>(p => {
                p.ToTable("permissions");
                p.Property(pm => pm.Id).HasColumnName("id");
                p.Property(pm => pm.Level).HasColumnName("level");
                p.Property(pm => pm.Description).HasColumnName("description");
                p.Property(pm => pm.RoleId).HasColumnName("role_id");

                p.HasOne(r => r.Role).WithMany(px => px.Permissions);
            });
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}