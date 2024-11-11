using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace PetShop.Models
{
    public class Empregados
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "O nome deve conter apenas letras.")]
        public string? NomeEmpregado { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "A função deve conter apenas letras.")]
        public string? Funcao { get; set; }
        public DateOnly dataAdmissao { get; set; }

        public List<Pedidos>? Pedidos { get; set; }

    }
}
