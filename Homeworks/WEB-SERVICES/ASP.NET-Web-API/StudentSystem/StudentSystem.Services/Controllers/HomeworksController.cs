namespace StudentSystem.Services.Controllers
{
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;

    using StudentSystem.Data;
    using StudentSystem.Services.Models;

    public class HomeworksController : ApiController
    {
        private IStudentSystemData data;

        public HomeworksController(IStudentSystemData studentSystemData)
        {
            this.data = studentSystemData;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Homeworks.All().ProjectTo<HomeworkModel>());
        }
    }
}