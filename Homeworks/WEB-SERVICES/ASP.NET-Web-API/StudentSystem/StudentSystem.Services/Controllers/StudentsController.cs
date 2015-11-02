namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Models;
    using StudentSystem.Models;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController(IStudentSystemData studentSystemData)
        {
            this.data = studentSystemData;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Students.All().ProjectTo<StudentModel>());
        }

        [HttpGet]
        public IHttpActionResult Find(int id)
        {
            var results = this.data.Students.SearchFor(x => x.StudentIdentification == id);

            if (results.Count() == 0)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(results.ProjectTo<StudentModel>());
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] StudentModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = Mapper.Map<Student>(model);

                this.data.Students.Add(result);

                return this.Created(this.Url.ToString(), result);
            }
        }

        [HttpPut]
        public IHttpActionResult Edit(int id, [FromBody] StudentModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var student = this.data.Students.SearchFor(x => x.StudentIdentification == id).FirstOrDefault();

                if (student == null)
                {
                    return this.NotFound();
                }
                else
                {
                    student.FirstName = model.FirstName;
                    student.LastName = model.LastName;

                    this.data.Students.Update(student);
                    return this.Ok(student);
                }
            }
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            var student = this.data.Students.SearchFor(x => x.StudentIdentification == id).FirstOrDefault();

            if (student == null)
            {
                return this.NotFound();
            }
            else
            {
                this.data.Students.Delete(student);
                return this.Ok(student);
            }
        }
    }
}