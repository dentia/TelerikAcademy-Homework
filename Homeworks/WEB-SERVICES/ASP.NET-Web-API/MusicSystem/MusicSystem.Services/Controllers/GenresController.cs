namespace MusicSystem.Services.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Data.Repositories;
    using Models;
    using MusicSystem.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GenresController : ApiController
    {
        private readonly IMusicSystemData data;

        public GenresController(IMusicSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Genres.All());
        }

        public IHttpActionResult Get(int id)
        {
            var genre = this.data.Genres.Find(id);

            if (genre == null)
            {
                return this.BadRequest("No such genre can be found.");
            }

            return this.Ok(genre);
        }

        public IHttpActionResult Post([FromBody]GenreDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var genre = new Genre
            {
                Name = model.Name
            };

            this.data.Genres.Add(genre);
            this.data.Savechanges();

            return this.Created(this.Url.ToString(), genre);
        }

        public IHttpActionResult Put(int id, [FromBody] GenreDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var genre = this.data.Genres.Find(id);

            if (genre == null)
            {
                return this.BadRequest("No such country can be found.");
            }

            genre.Name = model.Name;
            this.data.Genres.Update(genre);
            this.data.Savechanges();

            return this.Ok(genre);
        }

        public IHttpActionResult Delete(int id)
        {
            var deleted = this.data.Genres.Delete(id);
            this.data.Savechanges();
            return this.Ok(deleted);
        }
    }
}