using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Pedidos
    {
        public int Id { get; set; }
        [DisplayName("Serviço")]
        public Servicos? Servico { get; set; }
        public int ServicoId { get; set; }

        [DisplayName("Animal")]
        public Animais? Animal { get; set; }
        public int AnimalId { get; set; }

        [DisplayName("Empregado")]
        public Empregados? Empregado { get; set; }
        public int EmpregadoId { get; set; }
    }
}