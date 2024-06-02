using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.Models
{
    public class Passport
    {
        [Key]
        public int Id{ get; set; }

        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }

        [MaxLength(255)]
        public string ContractorCompleteName { get; set; }

        [MaxLength(255)]
        public string ContractorEmail { get; set; }

        [MaxLength(11)]
        public string ContractorCPF { get; set; }

        [MaxLength(11)]
        public string ContractorPhone { get; set; }

        [MaxLength(255)]
        public string PrenotamiEmail { get; set; }

        [MaxLength(255)]
        public string PrenotamiPassword { get; set; }

        [MaxLength(255)]
        public string FastitEmail { get; set; }

        [MaxLength(255)]
        public string FastitPassword { get; set; }

        public List<DateTime> DateUnavailability { get; set; }

        public bool HaveExpiredItalianPassport { get; set; }

        public bool HaveMinorChildren { get; set; }

        [Range(0, 99)]
        public int NumberOfMinorChildren { get; set; }

        [MaxLength(255)]
        public string CompleteResidentialAddress { get; set; }

        [MaxLength(255)]
        public string CivilState { get; set; }

        public DateTime DateOfExpiredItalianPassport { get; set; }

        [MaxLength(100)]
        public string MinorsCompleteNames { get; set; }

        [NotMapped]
        public byte[] IdentityDocument { get; set; }

        [NotMapped]
        public byte[] ProofOfResidence { get; set; }

        [NotMapped]
        public byte[] MinorsIdentityDocument { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual User User { get; set; }
    }
}

