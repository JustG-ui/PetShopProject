using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome deve conter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter exatamente 11 caracteres.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string CPF { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "O Telefone deve conter entre 10 e 11 caracteres.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O telefone deve conter apenas números.")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve conter exatamente 8 caracteres.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve conter apenas números.")]
        public string CEP { get; set; }

        public List<Animais>? Animal { get; set; }

    }
}