using System.ComponentModel.DataAnnotations.Schema;

namespace practica04.Models
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        [NotMapped]
        public Role Role { get; set; }

        [NotMapped]
        public Permission Permission { get; set; }
    }
}