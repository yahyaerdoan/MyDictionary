using Dictionary.DataAccessLayer.Abstract.IGenericRepositories;
using Dictionary.EntityLayer.Concrete;

namespace Dictionary.DataAccessLayer.Concrete
{
    public interface IContactDal : IGenericRepository<Contact>
    {
    }
}
