namespace MusicSystem.Services.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Data.Repositories;
    using Models;
    using MusicSystem.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CountriesController : ApiController
    {
        private readonly IMusicSystemData data;

        public CountriesController(IMusicSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Countries.All());
        }

        public IHttpActionResult Get(int id)
        {
            var country = this.data.Countries.Find(id);

            if (country == null)
            {
                return this.BadRequest("No such country can be found.");
            }

            return this.Ok(country);
        }

        public IHttpActionResult Post([FromBody]CountryDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var country = new Country
            {
                Name = model.Name
            };

            this.data.Countries.Add(country);
            this.data.Savechanges();

            return this.Created(this.Url.ToString(), country);
        }

        public IHttpActionResult Put(int id, [FromBody] CountryDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var country = this.data.Countries.Find(id);

            if (country == null)
            {
                return this.BadRequest("No such country can be found.");
            }

            country.Name = model.Name;
            this.data.Countries.Update(country);
            this.data.Savechanges();

            return this.Ok(country);
        }

        public IHttpActionResult Delete(int id)
        {
            var deleted = this.data.Countries.Delete(id);
            this.data.Savechanges();
            return this.Ok(deleted);
        }
    }
}