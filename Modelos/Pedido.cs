using System;
using System.Collections.Generic;

namespace Modelos;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdCliente { get; set; }

    public DateTime FechaHora { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Ordene> Ordenes { get; } = new List<Ordene>();
}
