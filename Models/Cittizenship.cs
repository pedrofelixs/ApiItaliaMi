using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace ApiItaliaMi.Models
{
    public class Cittizenship
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }

        [MaxLength(255)]    
        public string CustomerCompleteName { get; set; }

        [MaxLength(255)]
        public string ContractorEmail { get; set; }

        [MaxLength(11)]
        public string ContractorPhone { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual User User { get; set; }
    }
}
