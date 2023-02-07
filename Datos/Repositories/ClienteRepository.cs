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
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        private readonly GustitosDbContext _context;

        public ClienteRepository(GustitosDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> Deletear(int id)
        {
            Cliente modelo = _context.Clientes.First(c => c.IdCliente == id);
            _context.Clientes.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IQueryable<Cliente>> GetAll()
        {
            IQueryable<Cliente> queryPedidoSql = _context.Clientes;
            return queryPedidoSql;
        }

        public async Task<bool> Insertar(Cliente model)
        {
            _context.Clientes.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Updatear(Cliente model)
        {
            _context.Clientes.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
