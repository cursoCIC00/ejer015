using ejer15.Repository;
using ejer15.Servicios;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace ejer15
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IEntradasService, EntradasService>();
            container.RegisterType<IEntradasRepository, EntradasRepository>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}