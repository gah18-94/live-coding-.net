using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SecureFlight.Core.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();

        TEntity Update(TEntity entity);

        TEntity Save(TEntity entity);
    }
}
