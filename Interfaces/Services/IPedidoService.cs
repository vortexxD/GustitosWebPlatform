using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IPedidoService
    {
        Task<bool> Insertar(Pedido model);
        Task<bool> Updatear(Pedido model);
        Task<bool> Deletear(int id);
        Task<Pedido> Get(int id);
        Task<IQueryable<Pedido>> GetAll();
    }
}
