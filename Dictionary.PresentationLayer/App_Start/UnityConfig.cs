using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.BussinessLogicLayer.Concrete;
using Dictionary.DataAccessLayer.Concrete;
using Dictionary.DataAccessLayer.Context;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Dictionary.PresentationLayer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();           
            container.RegisterType<ICategoryDal, CategoryDal>();
            container.RegisterType<ICategoryService, CategoryManager>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}