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
    public class PedidoRepository : IGenericRepository<Pedido>
    {
        private readonly GustitosDbContext _context;
        public PedidoRepository(GustitosDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> Deletear(int id)
        {
            Pedido modelo = _context.Pedidos.First(c => c.IdPedido== id);
            _context.Pedidos.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Pedido> Get(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task<IQueryable<Pedido>> GetAll()
        {
            IQueryable<Pedido> queryPedidoSql = _context.Pedidos;
            return queryPedidoSql;
        }

        public async Task<bool> Insertar(Pedido model)
        {
            _context.Pedidos.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Updatear(Pedido model)
        {
            _context.Pedidos.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
