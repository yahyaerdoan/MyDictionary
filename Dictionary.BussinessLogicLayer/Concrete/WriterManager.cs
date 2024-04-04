using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.BussinessLogicLayer.Abstract.GenericService;
using Dictionary.DataAccessLayer.Concrete;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void TDeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void TDelete(Writer entity)
        {
            throw new NotImplementedException();
        }

        public List<Writer> TGetAllList()
        {
            return _writerDal.List();

        }

        public Writer TGetById(int id)
        {
           var values = _writerDal.GetById(id);
            return values;
        }

        public List<Writer> TListByFilter(Expression<Func<Writer, bool>> expression)
        {
            var values = _writerDal.ListByFilter(expression);
            return values;
        }

        public void TUpdate(Writer entity)
        {
            _writerDal.Update(entity);
        }

        Writer IGenericService<Writer>.TGetByIdWithFilter(Expression<Func<Writer, bool>> expression)
        {
            var values = _writerDal.GetByIdWithFilter(expression);
            return values;
        }

		public string TGetWriterInfoByReceverMail(string fullName)
		{
            var values = _writerDal.GetWriterInfoByReceverMail(fullName);
            return values;
		}

		public string TGetWriterInfoBySenderMail(string senderName)
		{
			var values = _writerDal.GetWriterInfoBySenderMail(senderName);
            return values;
		}
	}
}