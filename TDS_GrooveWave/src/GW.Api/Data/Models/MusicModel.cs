using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GW.Api.Data.Models
{
    public class MusicModel 
    {
        public MusicModel() { }

        public MusicModel(int musicId, string musicName , string TrackLink, string Photo, int AuthorId)
        {
            this.MusicId = musicId;
            this.MusicName = musicName;
            this.TrackLink = TrackLink;
            this.Photo = Photo;
            this.AuthorId = AuthorId;
        }
        [JsonIgnore]
        
        [Key]
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public int AuthorId { get; set; }
        public int AlbumId { get; set; }
        public string TrackLink { get; set; } = default!;
        public string Photo { get; set; } = default!;
        public List<PlayListModel>? Playlists { get; set; }

        // public List<int>? PlaylistsId { get; set; }

    }
}
