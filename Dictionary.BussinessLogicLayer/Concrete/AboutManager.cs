using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class AboutManager : IAboutService
    {
       

        public void TAdd(About entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(About entity)
        {
            throw new NotImplementedException();
        }

        public void TDeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetAllList()
        {
            throw new NotImplementedException();
        }

        public About TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public About TGetByIdWithFilter(Expression<Func<About, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<About> TListByFilter(Expression<Func<About, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About entity)
        {
            throw new NotImplementedException();
        }
    }
}
