using Dictionary.DataAccessLayer.Concrete;
using Dictionary.DataAccessLayer.Concrete.GenericRepositories;
using Dictionary.EntityLayer.Concrete;

namespace Dictionary.DataAccessLayer.Context
{
    public class WriterDal : GenericRepository<Writer>, IWriterDal
    {
    }   
}
