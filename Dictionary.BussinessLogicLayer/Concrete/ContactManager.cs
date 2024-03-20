using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.DataAccessLayer.Concrete;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class ContactManager : IContactService
    {
       private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TDeleteById(int id)
        {
            _contactDal.DeleteById(id);
        }

        public void TAdd(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public List<Contact> TGetAllList()
        {
            var values = _contactDal.List();
            return values;
        }

        public Contact TGetById(int id)
        {
            var values = _contactDal.GetById(id);
            return values;
        }

        public Contact TGetByIdWithFilter(Expression<Func<Contact, bool>> expression)
        {
            var values = _contactDal.GetByIdWithFilter(expression);
            return values;
        }

        public List<Contact> TListByFilter(Expression<Func<Contact, bool>> expression)
        {
            var values = _contactDal.ListByFilter(expression);
            return values;
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}