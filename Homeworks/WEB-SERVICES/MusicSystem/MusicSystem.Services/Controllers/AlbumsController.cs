namespace MusicSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicSystem.Data.Repositories;
    using MusicSystem.Models;
    using MusicSystem.Services.Models;

    public class AlbumsController : ApiController
    {
        private readonly IMusicSystemData data;

        public AlbumsController(IMusicSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Albums.All().ToList());
        }

        public IHttpActionResult Get(int id)
        {
            var country = this.data.Albums.Find(id);

            if (country == null)
            {
                return this.BadRequest("No such album can be found.");
            }

            return this.Ok(country);
        }

        public IHttpActionResult Post([FromBody]AlbumDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.data.Producers.Find(model.ProducerId) == null)
            {
                return this.BadRequest("No such producer can be found.");
            }

            var album = new Album
            {
                Name = model.Name,
                ProducerId = model.ProducerId,
                Year = model.Year
            };

            album = this.AddSongsToAlbum(model.SongIds, album);

            if (album == null)
            {
                return this.BadRequest("No such song can be found.");
            }

            this.data.Albums.Add(album);
            this.data.Savechanges();

            return this.Created(this.Url.ToString(), album);
        }

        public IHttpActionResult Put(int id, [FromBody] AlbumDataModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var album = this.data.Albums.Find(id);

            if (album == null)
            {
                return this.BadRequest("No such album can be found.");
            }

            if (this.data.Producers.Find(model.ProducerId) == null)
            {
                return this.BadRequest("No such producer can be found.");
            }

            album.Name = model.Name;
            album.Year = model.Year;
            album.ProducerId = model.ProducerId;

            album = this.AddSongsToAlbum(model.SongIds, album);

            if (album == null)
            {
                return this.BadRequest("No such song can be found.");
            }

            this.data.Albums.Update(album);
            this.data.Savechanges();

            return this.Ok(album);
        }

        public IHttpActionResult Delete(int id)
        {
            var deleted = this.data.Albums.Delete(id);
            this.data.Savechanges();
            return this.Ok(deleted);
        }

        private Album AddSongsToAlbum(int[] songIds, Album album)
        {
            album.Songs.Clear();

            foreach (var songId in songIds)
            {
                var songToAdd = this.data.Songs.Find(songId);

                if (songToAdd == null)
                {
                    return null;
                }

                album.Songs.Add(songToAdd);
            }

            return album;
        }
    }
}