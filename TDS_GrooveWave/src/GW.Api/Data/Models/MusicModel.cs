using System.Text.Json.Serialization;
using GW.Api.Data.Models.Shared;

namespace GW.Api.Data.Models
{
    public class MusicModel : Entity
    {
        //public MusicModel() { }

        public MusicModel(int musicId, string TrackLink, string Photo, int AuthorId)
        {
            this.MusicId = musicId;
            this.TrackLink = TrackLink;
            this.Photo = Photo;
            this.AuthorId = AuthorId;
        }
        [JsonIgnore]
        public int MusicId { get; set; }
        public int AuthorId { get; set; }
        public string TrackLink { get; set; } = default!;
        public string Photo { get; set; } = default!;
       // public List<PlayListModel>? Playlists { get; set; }

         public List<int>? PlaylistsId { get; set; }

    }
}
