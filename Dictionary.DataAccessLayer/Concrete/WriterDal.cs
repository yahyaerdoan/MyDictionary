using Dictionary.DataAccessLayer.Concrete;
using Dictionary.DataAccessLayer.Concrete.GenericRepositories;
using Dictionary.EntityLayer.Concrete;
using System.Linq;

namespace Dictionary.DataAccessLayer.Context
{
	public class WriterDal : GenericRepository<Writer>, IWriterDal
	{
		DbDictionaryContext _dbDictionaryContext = new DbDictionaryContext();

		public string GetWriterInfoByReceverMail(string fullName)
		{
			var values = _dbDictionaryContext.Writers.Where(x => x.Email == fullName).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
			return values;
		}
	}
}
