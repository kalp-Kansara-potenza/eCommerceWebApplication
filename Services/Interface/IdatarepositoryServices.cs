using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interface
{
    public interface IdatarepositoryServices<TEntity>
    {
        IEnumerable<TEntity> getAll();
        TEntity Get(int id);
        List<TEntity> Get();
        void Add(TEntity entity);
        void update(TEntity entity);
        void delete(int id);
    }
}
