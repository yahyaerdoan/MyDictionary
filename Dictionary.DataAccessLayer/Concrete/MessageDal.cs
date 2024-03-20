using Dictionary.DataAccessLayer.Abstract;
using Dictionary.DataAccessLayer.Concrete.GenericRepositories;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataAccessLayer.Concrete
{
    public class MessageDal : GenericRepository<Message>, IMessageDal
    {
    }
}