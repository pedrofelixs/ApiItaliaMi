using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.ViewModels
{
    public class EditPassportViewModel
    {
        [Required]
        public string ContractorCompleteName { get; set; }

        [Required]
        public string ContractorEmail { get; set; }

        [Required]
        public string ContractorPhone { get; set; }

        [Required]
        public string PrenotamiEmail { get; set; }

        [Required]
        public string PrenotamiPassword { get; set; }

        [Required]
        public string FastitEmail { get; set; }

        [Required]
        public string FastitPassword { get; set; }

        public List<DateTime> DateUnavailability { get; set; }

        public bool HaveExpiredItalianPassport { get; set; }

        public bool HaveMinorChildren { get; set; }

        [Range(0, 99)]
        public int NumberOfMinorChildren { get; set; }

        [Required]
        public string CompleteResidentialAddress { get; set; }

        [Required]
        public string CivilState { get; set; }

        [Required]
        public DateTime DateOfExpiredItalianPassport { get; set; }

        [Required]
        public string MinorsCompleteNames { get; set; }

        [Required]
        public UserViewModel User { get; set; }

        [Required]
        public CustomerViewModel Customer { get; set; }

    }
}
