using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public enum TipoServico
    {
        Banho,
        Tosa,
        Vacina,
        Consulta,
        Higienizacao,
        CorteUnhas,
        LimpezaOuvidos,
        HigieneBucal,
        DesemboloPelagem,
        TinturaPelos,
        ExameClinico,
        Vermifugacao,
        AplicacaoAntiparasitarios,
        Microchipagem,
        OrientacaoNutricional,
        Castracao,
        ExamesLaboratoriais,
        Hospedagem,
        Creche,
        Adestramento,
        Transporte,
        Reabilitacao,
        AtividadesRecreativas,
        AtendimentoEmergencia,
        PrimeirosSocorros
    }
    public class Servicos
    {
        public int Id { get; set; }

        [Required]
        [EnumDataType(typeof(TipoServico))]
        [DisplayName("Tipo de Serviço")]
        public TipoServico tipoServico { get; set; }
        public int preco { get; set; }
        public DateOnly data { get; set; }

        public List<Pedidos>? Pedidos { get; set; }


    }
}
