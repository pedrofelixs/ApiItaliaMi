using System.ComponentModel.DataAnnotations;

namespace ApiItaliaMi.Enums
{
    public enum ProofResidence
    {
        [Display(Name = "Conta de Energia Elétrica")]
        ContaEnergiaEletrica = 1,

        [Display(Name = "Conta de Água")]
        ContaAgua = 2,

        [Display(Name = "Conta de Gás")]
        ContaGas = 3,

        [Display(Name = "Conta de Celular")]
        ContaCelular = 4,

        [Display(Name = "Boleto Instituição de Ensino com Endereço")]
        BoletoInstituicaoEnsino = 5,

        [Display(Name = "Folha de Rosto da última Declaração do IR")]
        FolhaRostoUltimaDeclaracaoIR = 6,

        [Display(Name = "Contracheque recente")]
        ContrachequeRecente = 7,

        [Display(Name = "Certidão Expedida pelo Cartório Eleitoral")]
        CertidaoCartorioEleitoral = 8
    }
}
