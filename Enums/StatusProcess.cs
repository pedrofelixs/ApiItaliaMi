using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.Enums
{
    public enum StatusProcess
    {
        [Display(Name = "No aguardo")]
        NoAguardo = 1,

        [Display(Name = "Em processo")]
        EmProcesso = 2,

        [Display(Name = "Aguardando documentos")]
        AguardandoDocumentos= 3,

        [Display(Name = "Agendado")]
        Agendado = 4,

        [Display(Name = "Erro")]
        Erro = 5,

        [Display(Name = "Rejeitado")]
        Rejeitado =6,

        [Display(Name = "Finalizado")]
        Finalizado=7,

        [Display(Name = "Arquivado")]
        Arquivado=8
    }
}
