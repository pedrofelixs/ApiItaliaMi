using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.ViewModels
{
    public class EditUserViewModel
    {
        [Required (ErrorMessage = "O Nome de usuario é obrigatório")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="Este campo deve conter entre 3 e 100 caracteres")]
        public string Username { get; set; }

        [Required (ErrorMessage ="O Nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 100 caracteres")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="A função é obrigatória")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 100 e 3 caracteres")]
        public string Role { get; set; }
    }
}
