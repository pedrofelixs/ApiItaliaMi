using System.ComponentModel.DataAnnotations;
namespace ApiItaliaMi.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string CompleteName { get; set; }

        [MaxLength(255)]
        public string PersonalEmail { get; set; }

        [MaxLength(255)]
        public string PrenotamiEmail { get; set; }

        [MaxLength(255)]
        public string PrenotamiPassword { get; set; }

        [MaxLength(255)]
        public string FastitEmail { get; set; }

        [MaxLength(255)]
        public string FastitPassword { get; set; }

        [MaxLength(255)]
        public string Process { get; set; }
    }

}
