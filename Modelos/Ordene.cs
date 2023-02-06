using System;
using System.Collections.Generic;

namespace Modelos;

public partial class Ordene
{
    public int IdOrden { get; set; }

    public int? IdPedido { get; set; }

    public int? IdProducto { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
