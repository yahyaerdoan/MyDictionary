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
		DbDictionaryContext _dbDictionaryContext = new DbDictionaryContext();
		public string GetMessageInfoByReceverMail(string receverName)
		{
			var values = _dbDictionaryContext.Messages.Where(x => x.ReceverMail == receverName).Select(y => y.SenderMail).FirstOrDefault();
			return values;
		}

		public string GetMessageInfoBySenderMail(string senderName)
		{
			var values = _dbDictionaryContext.Messages.Where(x => x.SenderMail == senderName).Select(y => y.ReceverMail).FirstOrDefault();
			return values;
		}
	}
}