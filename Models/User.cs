using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.Models
{
    public class User

    {
        [Key]
        public int Id { get; set; }

        [MaxLength(32)]
        public string Username { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(11)]
        public string CPF { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string Role { get; set; }
    }
}
