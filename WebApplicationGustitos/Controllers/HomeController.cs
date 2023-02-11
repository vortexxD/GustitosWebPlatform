using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Diagnostics;
using WebApplicationGustitos.Models;
using WebApplicationGustitos.Models.ViewModels;

namespace WebApplicationGustitos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IProductoService _productoService;
        private readonly IPedidoService _pedidoService;

        public HomeController(IClienteService clienteService, IProductoService productoService, IPedidoService pedidoService)
        {
            _clienteService = clienteService;
            _productoService = productoService;
            _pedidoService = pedidoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            IQueryable<Producto> queryProductoSql = await _productoService.GetAll();
            IQueryable<Cliente> queryClienteSql = await _clienteService.GetAll();
            IQueryable<Pedido> queryPedidoSql = await _pedidoService.GetAll();

            List<ProductoViewModel> listaProducto = queryProductoSql.Select(c => new ProductoViewModel
            {
                IdProducto = c.IdProducto,
                Nombre= c.Nombre,
                Precio= c.Precio,
                Descripcion= c.Descripcion,
                IdCategoria= c.IdCategoria,
                Cantidad= c.Cantidad
            }).ToList();

            List<PedidoViewModel> listaPedido = queryPedidoSql.Select(c => new PedidoViewModel
            {
                IdPedido= c.IdPedido,
                IdCliente= c.IdCliente,
                FechaHora= c.FechaHora.ToString()
            }).ToList();

            List<ClienteViewModel> listaCliente = queryClienteSql.Select(c => new ClienteViewModel
            {
                IdCliente = c.IdCliente,
                Nombres = c.Nombres,
                Telefono = c.Telefono,
                Direccion = c.Direccion
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, listaProducto);
        }
        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] ProductoViewModel model)
        {
            Producto NuevoProducto = new Producto()
            {
                Nombre = model.Nombre,
                Precio = model.Precio,
                Descripcion = model.Descripcion,
                IdCategoria = model.IdCategoria,
                Cantidad = model.Cantidad
            };

            bool response = await _productoService.Insertar(NuevoProducto);

            return StatusCode(StatusCodes.Status200OK, new {valor = response});
        }
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ProductoViewModel model)
        {
            Producto NuevoProducto = new Producto()
            {
                IdProducto= model.IdProducto,
                Nombre = model.Nombre,
                Precio = model.Precio,
                Descripcion = model.Descripcion,
                IdCategoria = model.IdCategoria,
                Cantidad = model.Cantidad
            };

            bool response = await _productoService.Updatear(NuevoProducto);

            return StatusCode(StatusCodes.Status200OK, new { valor = response });
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool response = await _productoService.Deletear(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = response });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}