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
            _dbSet.Add(entity);
            _dbDictionaryContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
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
            _dbDictionaryContext.SaveChanges();
        }
    }
}
