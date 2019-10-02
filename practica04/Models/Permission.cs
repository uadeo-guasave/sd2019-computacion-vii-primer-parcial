using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practica04.Models
{
    public class Permission
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Description { get; set; }
        
        [Required]
        public PermissionLevel Level { get; set; }

        [NotMapped]
        public List<RolePermission> RolesPermissions { get; set; }
    }
    public enum PermissionLevel
    {
        DeniedAccess = 0,
        TotalAccess = 1,
        RestrictedAccess = 2
    }
}