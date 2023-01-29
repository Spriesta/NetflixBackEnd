using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Common
{
    interface IGenericRepository<TEntity> : IDisposable where TEntity: class
    {
        void Add(TEntity obj);

        TEntity Get(long id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Delete(TEntity obj);

        List<TEntity> Find(TEntity entity);

        IEnumerable<TEntity> Query(string Sql);
    }
}
