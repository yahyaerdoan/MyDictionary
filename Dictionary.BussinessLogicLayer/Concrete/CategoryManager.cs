using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.DataAccessLayer.Concrete;
using Dictionary.DataAccessLayer.Concrete.GenericRepositories;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {        
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void DeleteById(int id)
        {
            _categoryDal.DeleteById(id);
        }

        public void TAdd(Category entity)
        {
            if (entity.Name == "" || entity.Name.Length <= 3 || entity.Name.Length >= 20 || entity.Description == "")
            {
                //throw 
            }
            else
            {
                _categoryDal.Add(entity);
            }
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> TGetAllList()
        {
            return _categoryDal.List();
        }

        public Category TGetById(int id)
        {
            var values = _categoryDal.GetById(id);
            return values;
        }

        public List<Category> TListByFilter(Expression<Func<Category, bool>> expression)
        {
            var values = _categoryDal.ListByFilter(expression);
            return values;
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
