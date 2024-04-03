using Dictionary.BussinessLogicLayer.Abstract.GenericService;
using Dictionary.EntityLayer.Concrete;
using System.Collections.Generic;

namespace Dictionary.BussinessLogicLayer.Abstract
{
    public interface IContentService : IGenericService<Content>
    {
        List<Content> TGetContentByHeaderId(int id);
        List<Content> TGetContentByCategoryId(int id);
        List<Content> TGetContentBySearch(string search);
    }
}
