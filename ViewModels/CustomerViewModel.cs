using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.ViewModels
{
    public class CustomerViewModel
    {
        [Required]
        public string CompleteName { get; set; }

        [Required]
        public string PersonalEmail { get; set; }

        [Required]
        public string PrenotamiEmail { get; set; }

        [Required]
        public string PrenotamiPassword { get; set; }

        [Required]
        public string FastitEmail { get; set; }

        [Required]
        public string FastitPassword { get; set; }

        [Required]
        public string Process { get; set; }
    }
}
