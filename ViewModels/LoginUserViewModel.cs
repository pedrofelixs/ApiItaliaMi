using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.ViewModels
{
    public class LoginUserViewModel
    {
        public string CPF { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
