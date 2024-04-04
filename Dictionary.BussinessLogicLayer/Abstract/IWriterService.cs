using Dictionary.BussinessLogicLayer.Abstract.GenericService;
using Dictionary.EntityLayer.Concrete;
using System.Collections.Generic;

namespace Dictionary.BussinessLogicLayer.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        string TGetWriterInfoByReceverMail(string receverName);
        string TGetWriterInfoBySenderMail(string senderName);
    }
}
