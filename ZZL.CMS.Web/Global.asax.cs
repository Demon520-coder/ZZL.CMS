using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.ComponentModel.Composition;
using System.Reflection;
using System.ComponentModel.Composition.Hosting;

namespace ZZL.CMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //MEF设置：
            //01.获取当前运行的程序集所在目录:
            DirectoryCatalog catalog = new DirectoryCatalog(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath);
            var container = new CompositionContainer(catalog);
            MEFDependencyResovler dependency = new MEFDependencyResovler(container);
           
            DependencyResolver.SetResolver(dependency);
        }


        public class MEFDependencyResovler : IDependencyResolver
        {
            private readonly CompositionContainer _container;

            public MEFDependencyResovler(CompositionContainer container)
            {
                this._container = container;
            }

            public object GetService(Type serviceType)
            {
                string name = AttributedModelServices.GetContractName(serviceType);

                return _container.GetExportedValueOrDefault<object>(name);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _container.GetExportedValues<object>(serviceType.FullName);
            }
        }
    }
}
