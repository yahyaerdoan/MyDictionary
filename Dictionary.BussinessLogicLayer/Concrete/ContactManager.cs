﻿using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class ContactManager : IContactService
    {
        public void TDeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Contact entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetAllList()
        {
            throw new NotImplementedException();
        }

        public Contact TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Contact TGetByIdWithFilter(Expression<Func<Contact, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TListByFilter(Expression<Func<Contact, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
