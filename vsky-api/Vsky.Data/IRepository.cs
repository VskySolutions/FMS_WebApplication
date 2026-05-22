using System.Collections.Generic;
using System.Linq;
using Vsky.Core;

namespace Vsky.Data
{
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Methods

        TEntity GetById(object id);

        IList<TEntity> GetByIds(IList<object> ids);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        #endregion

        #region Properties

        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> TableNoTracking { get; }

        #endregion
    }
}