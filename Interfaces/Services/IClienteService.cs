using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IClienteService
    {
        Task<bool> Insertar(Cliente model);
        Task<bool> Updatear(Cliente model);
        Task<bool> Deletear(int id);
        Task<Cliente> Get(int id);
        Task<IQueryable<Cliente>> GetAll();
    }
}
