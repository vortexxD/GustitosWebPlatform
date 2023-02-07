using Datos.DataContext;
using Interfaces.Repositories;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{    
    public class ProductoRepository : IGenericRepository<Producto>
    {
        private readonly GustitosDbContext _context;
        public ProductoRepository(GustitosDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> Deletear(int id)
        {
            Producto modelo = _context.Productos.First(c => c.IdProducto == id);
            _context.Productos.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Producto> Get(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<IQueryable<Producto>> GetAll()
        {
            IQueryable<Producto> queryPedidoSql = _context.Productos;
            return queryPedidoSql;
        }

        public async Task<bool> Insertar(Producto model)
        {
            _context.Productos.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Updatear(Producto model)
        {
            _context.Productos.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
