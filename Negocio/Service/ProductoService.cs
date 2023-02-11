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
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _genericRepository;
        public ProductoService(IGenericRepository<Producto> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Deletear(int id)
        {
            return await _genericRepository.Deletear(id);
        }

        public async Task<Producto> Get(int id)
        {
            return await _genericRepository.Get(id);
        }

        public async Task<IQueryable<Producto>> GetAll()
        {
            return await _genericRepository.GetAll();
        }

        public async Task<Producto> GetByName(string name)
        {
            IQueryable<Producto> queryProductos = await _genericRepository.GetAll();
            Producto producto= queryProductos.Where(c => c.Nombre == name).FirstOrDefault();
            return producto;
        }

        public async Task<bool> Insertar(Producto model)
        {
            return await _genericRepository.Insertar(model);
        }

        public async Task<bool> Updatear(Producto model)
        {
            return await _genericRepository.Updatear(model);
        }
    }
}
