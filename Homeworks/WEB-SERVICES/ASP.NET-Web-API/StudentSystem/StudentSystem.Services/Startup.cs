namespace StudentSystem.Services
{
    using System.Web.Http;

    using AutoMapper;
    using Models;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;
    using StudentSystem.Models;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            MappingConfig.RegisterMappings();

            app.UseNinjectMiddleware(() => NinjectConfig.CreateKernel.Value);
            app.UseNinjectWebApi(config);
        }
    }
}