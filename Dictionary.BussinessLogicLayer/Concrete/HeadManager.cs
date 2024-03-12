using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class HeadManager : IHeadService
    {
        public void TAdd(Head entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Head> TGetAllList()
        {
            throw new NotImplementedException();
        }

        public Head TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Head> TListByFilter(Expression<Func<Head, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Head entity)
        {
            throw new NotImplementedException();
        }
    }
}
