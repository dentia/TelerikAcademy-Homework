namespace MusicSystem.Services.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Data.Repositories;
    using Models;
    using MusicSystem.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArtistsController : ApiController
    {
        private readonly IMusicSystemData data;

        public ArtistsController(IMusicSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Artists.All());
        }

        public IHttpActionResult Get(int id)
        {
            var artist = this.data.Artists.Find(id);

            if (artist == null)
            {
                return this.BadRequest("No such artist can be found.");
            }

            return this.Ok(artist);
        }

        public IHttpActionResult Post([FromBody]ArtistDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.data.Countries.Find(model.CountryId) == null)
            {
                return this.BadRequest("No such country can be found.");
            }

            var artist = new Artist
            {
                Name = model.Name,
                CountryId = model.CountryId
            };

            this.data.Artists.Add(artist);
            this.data.Savechanges();

            return this.Created(this.Url.ToString(), artist);
        }

        public IHttpActionResult Put(int id, [FromBody] ArtistDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artist = this.data.Artists.Find(id);

            if (artist == null)
            {
                return this.BadRequest("No such artist can be found.");
            }

            if (this.data.Countries.Find(model.CountryId) == null)
            {
                return this.BadRequest("No such country can be found.");
            }

            artist.Name = model.Name;
            artist.CountryId = model.CountryId;
            this.data.Artists.Update(artist);
            this.data.Savechanges();

            return this.Ok(artist);
        }

        public IHttpActionResult Delete(int id)
        {
            var deleted = this.data.Artists.Delete(id);
            this.data.Savechanges();
            return this.Ok(deleted);
        }
    }
}