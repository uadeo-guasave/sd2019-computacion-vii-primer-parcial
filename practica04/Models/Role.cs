using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public List<Permission> Permissions { get; set; }
    }
}