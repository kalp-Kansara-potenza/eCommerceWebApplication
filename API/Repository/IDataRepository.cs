using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Repository
{
    public interface IDataRepository<TEntity>
    {
        List<TEntity> getAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void update(TEntity entity);
        void delete(int id);
    }
}
