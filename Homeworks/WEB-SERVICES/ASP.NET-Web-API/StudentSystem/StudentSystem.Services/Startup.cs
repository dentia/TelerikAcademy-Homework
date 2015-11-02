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

            Mapper.CreateMap<Student, StudentModel>()
                .ForMember(
                dest => dest.Id,
                src => src.MapFrom(obj => obj.StudentIdentification));

            Mapper.CreateMap<StudentModel, Student>()
                .ForMember(
                dest => dest.StudentIdentification,
                src => src.MapFrom(obj => obj.Id));

            Mapper.CreateMap<Course, CourseModel>()
                .ForMember(
                dest => dest.CourseId,
                src => src.MapFrom(obj => obj.Id));
            Mapper.CreateMap<CourseModel, Course>();

            Mapper.CreateMap<Homework, HomeworkModel>();

            Mapper.CreateMap<Test, TestModel>();

            app.UseNinjectMiddleware(() => NinjectConfig.CreateKernel.Value);
            app.UseNinjectWebApi(config);
        }
    }
}