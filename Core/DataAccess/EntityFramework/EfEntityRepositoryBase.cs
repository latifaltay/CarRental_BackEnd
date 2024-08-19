using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _tContex;

        public EfEntityRepositoryBase(TContext tContex)
        {
            _tContex = tContex;
        }



        public void Add(TEntity entity)
        {
            var addedEntity = _tContex.Entry(entity);
            addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _tContex.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _tContex.Entry(entity);
            deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _tContex.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {

            return _tContex.Set<TEntity>().SingleOrDefault();

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _tContex.Set<TEntity>().ToList() : _tContex.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {

            var updatedEntity = _tContex.Entry(entity);
            updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _tContex.SaveChanges();

        }
    }
}
