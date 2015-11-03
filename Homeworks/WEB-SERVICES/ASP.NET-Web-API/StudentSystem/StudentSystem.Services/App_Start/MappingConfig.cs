using AutoMapper;
using StudentSystem.Models;
using StudentSystem.Services.Models;

namespace StudentSystem.Services
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
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
        }
    }
}