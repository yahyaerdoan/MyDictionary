using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Writer entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Writer entity)
        {
            throw new NotImplementedException();
        }

        public List<Writer> TGetAllList()
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Writer> TListByFilter(Expression<Func<Writer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Writer entity)
        {
            throw new NotImplementedException();
        }
    }
}
