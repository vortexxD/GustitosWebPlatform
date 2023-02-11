using Modelos;

namespace WebApplicationGustitos.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; } = null!;

        public float Precio { get; set; }

        public string Descripcion { get; set; } = null!;

        public int IdCategoria { get; set; }

        public int? Cantidad { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

        public virtual ICollection<Ordene> Ordenes { get; } = new List<Ordene>();
    }
}
