using Dictionary.DataAccessLayer.Abstract;
using Dictionary.DataAccessLayer.Concrete.GenericRepositories;
using Dictionary.DataAccessLayer.Context;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataAccessLayer.Concrete
{
    public class MessageDal : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetFullNameByFilter(Expression<Func<Message, bool>> expression)
        {
            using (DbDictionaryContext _dbDictionaryContext = new DbDictionaryContext())
            {
                var result = from message in _dbDictionaryContext.Messages
                             join writer in _dbDictionaryContext.Writers
                             on message.SenderMail equals writer.Email
                             select new Message
                             {
                                 SenderMail = writer.Email,
                                 ReceverMail = writer.Email

                             };
                return result.Where(expression).ToList();
            }
        }
    }
}