using Dictionary.DataAccessLayer.Abstract.IGenericRepositories;
using Dictionary.EntityLayer.Concrete;

namespace Dictionary.DataAccessLayer.Concrete
{
    public interface IWriterDal : IGenericRepository<Writer>
    {
        string GetWriterInfoByReceverMail(string fullName);
    }
}
