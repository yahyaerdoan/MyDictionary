using Dictionary.DataAccessLayer.Abstract.IGenericRepositories;
using Dictionary.EntityLayer.Concrete;
using Dictionary.EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericRepository<Message>
    {
        List<WriterMessageDto> GetMessageInfoByReceverMail(Expression<Func<WriterMessageDto, bool>> expression);
        List<WriterMessageDto> GetMessageInfoBySenderMail(Expression<Func<WriterMessageDto, bool>> expression);
    }
}
