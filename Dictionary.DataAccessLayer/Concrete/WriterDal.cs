using Dictionary.DataAccessLayer.Concrete;
using Dictionary.DataAccessLayer.Concrete.GenericRepositories;
using Dictionary.EntityLayer.Concrete;
using System.Linq;

namespace Dictionary.DataAccessLayer.Context
{
	public class WriterDal : GenericRepository<Writer>, IWriterDal
	{
		DbDictionaryContext _dbDictionaryContext = new DbDictionaryContext();

		public string GetWriterInfoByReceverMail(string receverName)
		{
			var values = _dbDictionaryContext.Writers.Where(x => x.Email == receverName).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
			return values;
		}

		public string GetWriterInfoBySenderMail(string senderName)
		{
			var values = _dbDictionaryContext.Writers.Where(x => x.Email == senderName).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
			return values;
		}
	}
}
