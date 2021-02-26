using System.Web.Mvc;
using _9ineMVCApplication.Interfaces;
using _9ineMVCApplication.Repository;
using Unity;
using Unity.Mvc5;

namespace _9ineMVCApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IDAL, DALClass>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}