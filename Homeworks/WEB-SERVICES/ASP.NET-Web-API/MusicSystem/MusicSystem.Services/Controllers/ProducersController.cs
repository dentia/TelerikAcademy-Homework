namespace MusicSystem.Services.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Data.Repositories;
    using Models;
    using MusicSystem.Models;
        
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProducersController : ApiController
    {
        private readonly IMusicSystemData data;

        public ProducersController(IMusicSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Producers.All());
        }

        public IHttpActionResult Get(int id)
        {
            var producer = this.data.Producers.Find(id);

            if (producer == null)
            {
                return this.BadRequest("No such producer can be found.");
            }

            return this.Ok(producer);
        }

        public IHttpActionResult Post([FromBody]ProducerDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var producer = new Producer
            {
                Name = model.Name
            };

            this.data.Producers.Add(producer);
            this.data.Savechanges();

            return this.Created(this.Url.ToString(), producer);
        }

        public IHttpActionResult Put(int id, [FromBody] ProducerDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var producer = this.data.Producers.Find(id);

            if (producer == null)
            {
                return this.BadRequest("No such producer can be found.");
            }

            producer.Name = model.Name;
            this.data.Producers.Update(producer);
            this.data.Savechanges();

            return this.Ok(producer);
        }

        public IHttpActionResult Delete(int id)
        {
            var deleted = this.data.Producers.Delete(id);
            this.data.Savechanges();
            return this.Ok(deleted);
        }
    }
}