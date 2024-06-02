using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.ViewModels
{
    public class EditPassportViewModel
    {
        [Required]
        public string PassportNumber { get; set; }

        [Required]
        public string IssuingCountry { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string OwnerName { get; set; }
    }
}
