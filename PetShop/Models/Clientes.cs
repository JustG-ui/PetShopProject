using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF must be exactly 11 characters.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF must contain only numbers.")]
        public string CPF { get; set; }

        [StringLength(11, MinimumLength = 10, ErrorMessage = "Telefone must be between 10 and 11 characters.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone must contain only numbers.")]
        public string Telefone { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP must be exactly 8 characters.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP must contain only numbers.")]
        public string CEP { get; set; }

        public List<Animais>? Animal { get; set; }
    }
}
