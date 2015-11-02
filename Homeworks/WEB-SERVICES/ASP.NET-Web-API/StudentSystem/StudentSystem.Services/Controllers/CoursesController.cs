namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController(IStudentSystemData studentSystemData)
        {
            this.data = studentSystemData;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Courses.All().ProjectTo<CourseModel>());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] CourseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = Mapper.Map<Course>(model);

                this.data.Courses.Add(result);

                return this.Created(this.Url.ToString(), result);
            }
        }

        [HttpPut]
        public IHttpActionResult Edit([FromBody] CourseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var course = this.data.Courses.SearchFor(x => x.Name == model.Name).FirstOrDefault();

                if (course == null)
                {
                    return this.NotFound();
                }
                else
                {
                    course.Description = model.Description;

                    this.data.Courses.Update(course);
                    return this.Ok(course);
                }
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove([FromBody] string guid)
        {
            var course = this.data.Courses.SearchFor(x => x.Id.ToString() == guid).FirstOrDefault();

            if (course == null)
            {
                return this.NotFound();
            }
            else
            {
                this.data.Courses.Delete(course);
                return this.Ok(course);
            }
        }
    }
}