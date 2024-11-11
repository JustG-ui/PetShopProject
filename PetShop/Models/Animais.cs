using System.ComponentModel;

namespace PetShop.Models
{
    public class Animais
    {
        public int Id { get; set; }
        public string? tipo { get; set; }
        public string? raca { get; set; }
        public string? nomeAnimal { get; set; }
        public int? Idade { get; set; }

        [DisplayName("Cliente")]
        public Clientes? Clientes { get; set; }
        public int ClientesId { get; set; }
        public List<Pedidos>? Pedidos { get; set; }
    }
}
