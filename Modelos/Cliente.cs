using System;
using System.Collections.Generic;

namespace Modelos;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombres { get; set; }

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
