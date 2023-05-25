using System.Web.Mvc;
using AtddSampleWeb.Models;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace AtddSampleWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IBookService, BookService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}