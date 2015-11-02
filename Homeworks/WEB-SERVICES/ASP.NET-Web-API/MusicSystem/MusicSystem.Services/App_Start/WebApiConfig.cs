namespace MusicSystem.Services
{
    using System.Data.Entity;
    using System.Web.Http;

    using Data;
    using Data.Migrations;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicSystemDbContext, Configuration>());

            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
