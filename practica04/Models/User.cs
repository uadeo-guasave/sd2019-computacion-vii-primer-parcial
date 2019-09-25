using System.ComponentModel.DataAnnotations;

namespace practica04.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(16)]
        public string Name { get; set; }
        [Required, MaxLength(200)]
        public string Password { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(300)]
        public string RememberToken { get; set; }
        [Required]
        public UserStatus Status { get; set; } = UserStatus.Active; // Active Inactive
    }

    public enum UserStatus
    {
        Active = 1, Inactive = 0
    }
}