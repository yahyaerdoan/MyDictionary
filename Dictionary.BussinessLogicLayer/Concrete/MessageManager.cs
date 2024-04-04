using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.DataAccessLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        public readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void TDelete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public void TDeleteById(int id)
        {
            _messageDal.DeleteById(id);           
        }

        public List<Message> TGetAllList()
        {
            var values = _messageDal.List();
            return values;
        }

        public Message TGetById(int id)
        {
            var values = _messageDal.GetById(id);
            return values;
        }

        public Message TGetByIdWithFilter(Expression<Func<Message, bool>> expression)
        {
            var values = _messageDal.GetByIdWithFilter(expression);
            return values;
        }

        public List<Message> TListByFilter(Expression<Func<Message, bool>> expression)
        {
            var values = _messageDal.ListByFilter(expression);
            return values;
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }

		public string TGetMessageInfoByReceverMail(string receverName)
		{
            var values = _messageDal.GetMessageInfoByReceverMail(receverName);
            return values;
		}

		public string TGetMessageInfoBySenderMail(string senderName)
		{
            var values = _messageDal.GetMessageInfoBySenderMail(senderName);
            return values;
		}
	}
}