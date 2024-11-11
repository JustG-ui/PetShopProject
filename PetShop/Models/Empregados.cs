using System.ComponentModel;
using System.Drawing;

namespace PetShop.Models
{
    public class Empregados
    {
        public int Id { get; set; }

        public string? NomeEmpregado { get; set; }
        public string? Funcao { get; set; }
        public DateOnly dataAdmissao { get; set; }

        public List<Pedidos>? Pedidos { get; set; }

    }
}
