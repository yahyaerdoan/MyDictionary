using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataAccessLayer.Abstract.IGenericRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(int id);
        void Update(TEntity entity);
        TEntity GetById(int id);
        List<TEntity> List();
        List<TEntity> ListByFilter(Expression<Func<TEntity, bool>> expression);
    }
}
