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
	public class AdminManager : IAdminService
	{
		private readonly IAdminDal _adminDal;

		public AdminManager(IAdminDal adminDal)
		{
			_adminDal = adminDal;
		}

		public void TAdd(Admin entity)
		{
			_adminDal.Add(entity);
		}

		public void TDelete(Admin entity)
		{
			_adminDal.Delete(entity);
		}

		public void TDeleteById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Admin> TGetAllList()
		{
			return _adminDal.List();
		}

		public Admin TGetById(int id)
		{
			return _adminDal.GetById(id);
		}

		public Admin TGetByIdWithFilter(Expression<Func<Admin, bool>> expression)
		{
			return _adminDal.GetByIdWithFilter(expression);
		}

		public List<Admin> TListByFilter(Expression<Func<Admin, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Admin entity)
		{
			_adminDal.Update(entity);
		}
	}
}
