namespace StudentSystem.Services.Controllers
{
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;

    using Data;
    using Models;
    
    public class TestsController : ApiController
    {
        private IStudentSystemData data;

        public TestsController(IStudentSystemData studentSystemData)
        {
            this.data = studentSystemData;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Tests.All().ProjectTo<TestModel>());
        }
    }
}