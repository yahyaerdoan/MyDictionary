using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.DataAccessLayer.Concrete;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class ContentManager : IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

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
            return _contentDal.List();
        }

        public Content TGetById(int id)
        {
            var values = _contentDal.GetById(id);
            return values;
        }

        public Content TGetByIdWithFilter(Expression<Func<Content, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Content> TListByFilter(Expression<Func<Content, bool>> expression)
        {
            var values = _contentDal.ListByFilter(expression);
            return values;
        }

        public void TUpdate(Content entity)
        {
            throw new NotImplementedException();
        }

        public List<Content> TGetContentByHeaderId(int id)
        {
            var values = _contentDal.ListByFilter(a => a.HeadId == id);
            return values;
        }

        public List<Content> TGetContentByCategoryId(int id)
        {
            var values = _contentDal.ListByFilter(a => a.Head.Category.CategoryId == id);
            return values;
        }
    }
}
