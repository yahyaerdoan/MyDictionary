using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.BussinessLogicLayer.Abstract.GenericService
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        void TAdd(TEntity entity);
        void TDelete(TEntity entity);
        void DeleteById(int id);
        void TUpdate(TEntity entity);
        List<TEntity> TGetAllList();
        TEntity TGetById(int id);
        List<TEntity> TListByFilter(Expression<Func<TEntity, bool>> expression);
    }
}
