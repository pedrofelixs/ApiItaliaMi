using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.Enums
{
    public enum StatusAccount
    {
        [Display(Name = "Cidadania")]
        Cidadania  = 1,

        [Display(Name = "Passaporte")]
        Passaporte = 2
    }
}
