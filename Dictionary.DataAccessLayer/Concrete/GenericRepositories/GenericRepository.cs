using Dictionary.DataAccessLayer.Abstract.IGenericRepositories;
using Dictionary.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataAccessLayer.Concrete.GenericRepositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbDictionaryContext _dbDictionaryContext = new DbDictionaryContext();

        DbSet<TEntity> _dbSet;
        public GenericRepository()
        {
            _dbSet = _dbDictionaryContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            var addedEntity = _dbDictionaryContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            //_dbSet.Add(entity);
            _dbDictionaryContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _dbDictionaryContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _dbSet.Remove(entity);
            _dbDictionaryContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var values = _dbSet.Find(id);
            _dbSet.Remove(values);
            _dbDictionaryContext.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            var values = _dbSet.Find(id);
            return values;
        }

        public TEntity GetByIdWithFilter(Expression<Func<TEntity, bool>> expression)
        {
            var values = _dbSet.SingleOrDefault(expression);
            return values;
        }

        public List<TEntity> List()
        {
            var values = _dbSet.ToList();
            return values;
        }

        public List<TEntity> ListByFilter(Expression<Func<TEntity, bool>> expression)
        {
            var values = _dbSet.Where(expression).ToList();
            return values;
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = _dbDictionaryContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _dbDictionaryContext.SaveChanges();
        }
    }
}
