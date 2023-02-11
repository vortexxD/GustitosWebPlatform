using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IProductoService
    {
        Task<bool> Insertar(Producto model);
        Task<bool> Updatear(Producto model);
        Task<bool> Deletear(int id);
        Task<Producto> Get(int id);
        Task<IQueryable<Producto>> GetAll();

        Task<Producto> GetByName(String name);
    }
}
