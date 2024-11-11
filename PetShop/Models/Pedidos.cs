using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }

        public int AnimalId { get; set; }
        public int ServicoId { get; set; }
        public int EmpregadoId { get; set; }

        // Navigation properties
        public Animais Animais { get; set; }
        public Servicos Servicos { get; set; }
        public Empregados Empregados { get; set; }
    }

}
