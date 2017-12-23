using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestMultiplica.Application.Infraestructure;
using TestMultiplica.Util;
using Ninject;
using TestMultiplica.Web.App_Start;

namespace TestMultiplica.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ApplicationProfile());
            });

            var Util = NinjectWebCommon.Kernel.Get<IUtil>();
            Util.GenerateXMLSeed();
        }
    }
}
