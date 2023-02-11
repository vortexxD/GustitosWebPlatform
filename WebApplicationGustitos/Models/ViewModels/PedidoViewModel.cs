using Modelos;

namespace WebApplicationGustitos.Models.ViewModels
{
    public class PedidoViewModel
    {
        public int IdPedido { get; set; }

        public int IdCliente { get; set; }

        public string? FechaHora { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;

        public virtual ICollection<Ordene> Ordenes { get; } = new List<Ordene>();
    }
}
