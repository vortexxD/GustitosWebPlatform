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
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _genericRepository;
        public ClienteService(IGenericRepository<Cliente> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Deletear(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Cliente>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insertar(Cliente model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Updatear(Cliente model)
        {
            throw new NotImplementedException();
        }
    }
}
