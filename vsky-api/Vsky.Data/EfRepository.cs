using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Vsky.Core;

namespace Vsky.Data
{
    public partial class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        private DbSet<TEntity> _entities;

        #endregion

        #region Ctor

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Utilities

        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            // rollback entity changes
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                        // ignored
                    }
                });
            }

            try
            {
                _context.SaveChanges();

                return exception.ToString();
            }
            catch (Exception ex)
            {
                // if after the rollback of changes the context is still not saving,
                // return the full text of the exception that occurred when saving
                return ex.ToString();
            }
        }

        #endregion

        #region Methods

        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual IList<TEntity> GetByIds(IList<object> ids)
        {
            if (!ids?.Any() ?? true)
            {
                return new List<TEntity>();
            }

            return Entities.Where(x => ids.Contains(x.Id)).ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                // ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            try
            {
                Entities.AddRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                // ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                Entities.Update(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                // ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            try
            {
                Entities.UpdateRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                // ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                // ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            try
            {
                Entities.RemoveRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                // ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        #endregion

        #region Properties

        public virtual IQueryable<TEntity> Table => Entities;

        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                _entities ??= _context.Set<TEntity>();

                return _entities;
            }
        }

        #endregion
    }
}