namespace MusicSystem.Services.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Data.Repositories;
    using Models;
    using MusicSystem.Models;
    
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SongsController : ApiController
    {
        private readonly IMusicSystemData data;

        public SongsController(IMusicSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Songs.All());
        }

        public IHttpActionResult Get(int id)
        {
            var song = this.data.Songs.Find(id);

            if (song == null)
            {
                return this.BadRequest("No such song can be found.");
            }

            return this.Ok(song);
        }

        public IHttpActionResult Post([FromBody]SongDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.data.Genres.Find(model.GenreId) == null)
            {
                return this.BadRequest("No such genre can be found.");
            }

            var song = new Song
            {
                Name = model.Name,
                GenreId = model.GenreId,
                Year = model.Year
            };

            this.data.Songs.Add(song);
            this.data.Savechanges();

            return this.Created(this.Url.ToString(), song);
        }

        public IHttpActionResult Put(int id, [FromBody] SongDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var song = this.data.Songs.Find(id);

            if (song == null)
            {
                return this.BadRequest("No such song can be found.");
            }

            if (this.data.Genres.Find(model.GenreId) == null)
            {
                return this.BadRequest("No such genre can be found.");
            }

            song.Name = model.Name;
            song.Year = model.Year;
            song.GenreId = model.GenreId;
            this.data.Songs.Update(song);
            this.data.Savechanges();

            return this.Ok(song);
        }

        public IHttpActionResult Delete(int id)
        {
            var deleted = this.data.Songs.Delete(id);
            this.data.Savechanges();
            return this.Ok(deleted);
        }
    }
}