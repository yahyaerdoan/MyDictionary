﻿using Dictionary.BussinessLogicLayer.Abstract;
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

        public void TDeleteById(int id)
        {
            _categoryDal.DeleteById(id);
        }

        public void TAdd(Category entity)
        {
           _categoryDal.Add(entity);            
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

        public Category TGetByIdWithFilter(Expression<Func<Category, bool>> expression)
        {
            var values = _categoryDal.GetByIdWithFilter(expression);
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

        public int TGetCategoryCount()
        {
            var values = _categoryDal.GetCategoryCount();
            return values;
        }
    }
}