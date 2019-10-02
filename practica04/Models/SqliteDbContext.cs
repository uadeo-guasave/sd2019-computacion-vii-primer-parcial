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
            modelBuilder.Entity<User>(u =>
            {
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

                u.Property(p => p.RememberToken).HasDefaultValue(null);

                u.HasOne(user => user.Role).WithMany(role => role.Users);
            });

            modelBuilder.Entity<Role>(r =>
            {
                r.ToTable("roles");
                r.Property(p => p.Id).HasColumnName("id");
                r.Property(p => p.Name).HasColumnName("name");

                r.HasIndex(p => p.Name).IsUnique();

                r.HasMany(role => role.Users).WithOne(user => user.Role);
                r.HasMany(role => role.RolesPermissions).WithOne(rp => rp.Role);
            });

            modelBuilder.Entity<Permission>(p =>
            {
                p.ToTable("permissions");
                p.Property(pm => pm.Id).HasColumnName("id");
                p.Property(pm => pm.Level).HasColumnName("level");
                p.Property(pm => pm.Description).HasColumnName("description");

                p.HasMany(m => m.RolesPermissions).WithOne(rp => rp.Permission);
            });

            modelBuilder.Entity<RolePermission>(rp =>
            {
                rp.ToTable("roles_permissions");
                rp.Property(p => p.RoleId).HasColumnName("role_id");
                rp.Property(p => p.PermissionId).HasColumnName("permission_id");

                rp.HasKey(k => new { k.RoleId, k.PermissionId });

                rp.HasOne(p => p.Role).WithMany(r => r.RolesPermissions).IsRequired();
                rp.HasOne(p => p.Permission).WithMany(m => m.RolesPermissions).IsRequired();
            });

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}