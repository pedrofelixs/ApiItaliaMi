using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.ViewModels
{
    public class CreateCittizenshipViewModel
    {
        [Required]
        public string CustomerCompleteName { get; set; }

        [Required]
        public string ContractorEmail { get; set; }

        [Required]
        public string ContractorPhone { get; set; }

        [Required]
        public CustomerViewModel Customer { get; set; }

        [Required]
        public UserViewModel User { get; set; }
    }
}
