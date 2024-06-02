using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.Enums
{
    public enum IdentityDocuments
    {
        [Display(Name = "RG")]
        Rg = 1,

        [Display(Name = "RNE")]
        Rne = 2,

        [Display(Name = "Passaporte do País de Origem")]
        Passaporte = 3,

        [Display(Name = "Carteira de Habilitação Italiana")]
        CarteiraHabilitacaoItaliana = 4
    }
}
