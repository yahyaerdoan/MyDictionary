using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class ContentManager : IContentService
    {
        public void TDeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Content entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Content entity)
        {
            throw new NotImplementedException();
        }

        public List<Content> TGetAllList()
        {
            throw new NotImplementedException();
        }

        public Content TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Content TGetByIdWithFilter(Expression<Func<Content, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Content> TListByFilter(Expression<Func<Content, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Content entity)
        {
            throw new NotImplementedException();
        }
    }
}
