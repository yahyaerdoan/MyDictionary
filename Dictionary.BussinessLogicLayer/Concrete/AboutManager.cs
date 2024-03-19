using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.DataAccessLayer.Concrete;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
            _aboutDal.Add(entity);
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
            var values = _aboutDal.List();
            return values;
        }

        public About TGetById(int id)
        {
            var values = _aboutDal.GetById(id);
            return values;
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
            _aboutDal.Update(entity);
        }
    }
}
