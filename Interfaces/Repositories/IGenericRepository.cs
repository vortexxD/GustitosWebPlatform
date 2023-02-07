using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repositories
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool> Insertar(TEntityModel model);
        Task<bool> Updatear(TEntityModel model);
        Task<bool> Deletear(int id);
        Task<TEntityModel> Get(int id);
        Task<IQueryable<TEntityModel>> GetAll();
    }
}
