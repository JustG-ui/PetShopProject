using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Servicos
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "O tipo deve conter apenas letras.")]
        public string tipoServico { get; set; }
        public int preco { get; set; }
        public DateOnly data { get; set; }

        public List<Pedidos>? Pedidos { get; set; }
    }
}
