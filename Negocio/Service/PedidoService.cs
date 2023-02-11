using Interfaces.Repositories;
using Interfaces.Services;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IGenericRepository<Pedido> _genericRepository;
        public PedidoService(IGenericRepository<Pedido> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Deletear(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pedido> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Pedido>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insertar(Pedido model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Updatear(Pedido model)
        {
            throw new NotImplementedException();
        }
    }
}
