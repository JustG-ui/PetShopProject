using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Animais
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "O tipo deve conter apenas letras.")]
        public string? tipo { get; set; }

        public string? raca { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "O nome deve conter apenas letras.")]
        public string? nomeAnimal { get; set; }

        public int? Idade { get; set; }

        [DisplayName("Cliente")]
        public Clientes? Clientes { get; set; }
        public int ClientesId { get; set; }
        public List<Pedidos>? Pedidos { get; set; }
    }
}
