using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.DataAccessLayer.Concrete;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class HeadManager : IHeadService
    {
        private readonly IHeadDal _headDal;

        public HeadManager(IHeadDal headDal)
        {
            _headDal = headDal;
        }

        public void TDeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Head entity)
        {
            _headDal.Add(entity);
        }

        public void TDelete(Head entity)
        {
            _headDal.Delete(entity);
        }

        public List<Head> TGetAllList()
        {
            var values = _headDal.List();
            return values;
        }

        public Head TGetById(int id)
        {
            var values = _headDal.GetById(id);
            return values;
        }

        public Head TGetByIdWithFilter(Expression<Func<Head, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Head> TListByFilter(Expression<Func<Head, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Head entity)
        {
            _headDal.Update(entity);
        }
    }
}
