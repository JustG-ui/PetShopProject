using System.ComponentModel;

namespace PetShop.Models
{
    public class Pedidos
    {
        public int AnimalId { get; set; }
        public int ServicoId { get; set; }
        public int EmpregadoId { get; set; }

        // Navigation properties
        public Animais Animais { get; set; }
        public Servicos Servicos { get; set; }
        public Empregados Empregados { get; set; }
    }

}
