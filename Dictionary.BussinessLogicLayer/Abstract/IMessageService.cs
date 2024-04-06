using Dictionary.BussinessLogicLayer.Abstract.GenericService;
using Dictionary.EntityLayer.Concrete;
using Dictionary.EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.BussinessLogicLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<WriterMessageDto> TGetMessageInfoByReceverMail(Expression<Func<WriterMessageDto, bool>> expression);
        string TGetMessageInfoBySenderMail(string senderName);
    }
}