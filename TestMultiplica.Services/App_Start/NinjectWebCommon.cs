using AutoMapper;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TestMultiplica.Application.Category.Queries.GetCategories;
using TestMultiplica.Application.Product.Queries.GetProducts;
using TestMultiplica.Application.Product.Queries.GetProductByID;
using TestMultiplica.Application.Product.Commands.CreateProduct;
using TestMultiplica.Application.Product.Commands.UpdateProduct;
using TestMultiplica.Application.Product.Commands.DeleteProduct;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TestMultiplica.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TestMultiplica.Web.App_Start.NinjectWebCommon), "Stop")]

namespace TestMultiplica.Web.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IGetCategoriesQuery>().To<GetCategoriesQuery>();
            kernel.Bind<IGetProductsQuery>().To<GetProductsQuery>();
            kernel.Bind<IGetProductByIDQuery>().To<GetProductByIDQuery>();
            kernel.Bind<ICreateProductCommand>().To<CreateProductCommand>();
            kernel.Bind<IUpdateProductCommand>().To<UpdateProductCommand>();
            kernel.Bind<IDeleteProductCommand>().To<DeleteProductCommand>();
        }
    }
}