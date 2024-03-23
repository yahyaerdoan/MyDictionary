using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.DataAccessLayer.Concrete;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.BussinessLogicLayer.Concrete
{
    public class GalleryManager : IGalleryService
    {
        private readonly IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        public void TAdd(Gallery entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Gallery entity)
        {
            throw new NotImplementedException();
        }

        public void TDeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Gallery> TGetAllList()
        {
            var values = _galleryDal.List();
            return values;
        }

        public Gallery TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Gallery TGetByIdWithFilter(Expression<Func<Gallery, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Gallery> TListByFilter(Expression<Func<Gallery, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Gallery entity)
        {
            throw new NotImplementedException();
        }
    }
}
