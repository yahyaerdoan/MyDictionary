using Dictionary.DataAccessLayer.Abstract;
using Dictionary.DataAccessLayer.Concrete.GenericRepositories;
using Dictionary.DataAccessLayer.Context;
using Dictionary.EntityLayer.Concrete;
using Dictionary.EntityLayer.Dto;
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
		public List<WriterMessageDto> GetMessageInfoByReceverMail(Expression<Func<WriterMessageDto, bool>> expression)
        {
            using (DbDictionaryContext _dbDictionaryContext = new DbDictionaryContext())
            {
				var query = from message in _dbDictionaryContext.Messages
							join writer in _dbDictionaryContext.Writers							
							on message.ReceverMail equals writer.Email							
							select new WriterMessageDto()
							{								
								MessageId = message.MessageId,
								Content = message.Content,
								Status = message.Status,
								Subject = message.Subject,
								ReceverMail = message.ReceverMail,
								SenderMail = message.SenderMail,
								Date = message.Date,
								FirstName = writer.FirstName,
								LastName = writer.LastName,
								Email = writer.Email
							};
				query = query.Where(expression).OrderByDescending(x=> x.Date);
				var result = query.ToList();
				return result;
            }
        }

        public List<WriterMessageDto> GetMessageInfoBySenderMail(Expression<Func<WriterMessageDto, bool>> expression)
        {

			using (DbDictionaryContext _dbDictionaryContext = new DbDictionaryContext())
			{
				var query = from message in _dbDictionaryContext.Messages
							join writer in _dbDictionaryContext.Writers
							on message.SenderMail equals writer.Email						
							select new WriterMessageDto()
							{								
								MessageId = message.MessageId,
								Content = message.Content,
								Status = message.Status,
								Subject = message.Subject,
								ReceverMail = message.ReceverMail,
								SenderMail = message.SenderMail,
								Date = message.Date,
								FirstName = writer.FirstName,
								LastName = writer.LastName,
								Email = writer.Email
							};
				query = query.Where(expression).OrderByDescending(x => x.Date);
				var result = query.ToList();
				return result;
			}
		}
    }
}