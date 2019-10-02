using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace practica04.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required, MaxLength(16)]
        public string Name { get; set; }

        // EFCore requirement for FK constraints
        [NotMapped]
        public List<User> Users { get; set; }
        
        [NotMapped]
        public List<RolePermission> RolesPermissions { get; set; }

        public override string ToString()
        {
            // [1]:Administrador
            return $"[{Id}]:{Name}";
        }

        public static string ToStringList()
        {
            // [1]:Administrador [2]:Usuario [3]:Invitado
            using (var db = new SqliteDbContext())
            {
                var roles = db.Roles.ToList();
                return string.Join(" ", roles);
            }
        }
    }
}