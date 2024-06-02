using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.Enums
{
    public enum CivilState
    {
        [Display(Name = "Casado/a")]
        Casado = 1,

        [Display(Name = "Divorciado/a")]
        Divorciado = 2,

        [Display(Name = "Viúvo/a")]
        Viuvo = 3,

        [Display(Name = "Solteiro/a")]
        Solteiro = 4,

        [Display(Name = "Separado/a")]
        Separado = 5,

        [Display(Name = "Em União Civil")]
        EmUniaoCivil = 6,

        [Display(Name = "Casado/a de União Civil")]
        CasadoUniaoCivil = 7,

        [Display(Name = "Divorciado/a de União Civil")]
        DivorciadoUniaoCivil = 8,

        [Display(Name = "Viúvo/a de União Civil")]
        ViuvoUniaoCivil = 9
    }
}
