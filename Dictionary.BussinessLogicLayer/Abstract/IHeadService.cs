using Dictionary.BussinessLogicLayer.Abstract.GenericService;
using Dictionary.EntityLayer.Concrete;

namespace Dictionary.BussinessLogicLayer.Abstract
{
    public interface IHeadService : IGenericService<Head>
    {
        void UpdateAsAFalse(Head head);
        void UpdateAsATrue(Head head);
    }
}
