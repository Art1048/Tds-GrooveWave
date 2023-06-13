using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GW.Api.Data.Models
{
    public class MusicModel 
    {
        public MusicModel() { }

        public MusicModel(int musicId, string musicName , string trackLink, string photo, int authorId , string authorName)
        {
            this.MusicId = musicId;
            this.MusicName = musicName;
            this.TrackLink = trackLink;
            this.Photo = photo;
            this.AuthorId = authorId;
            this.AuthorName = authorName;
        }
        [JsonIgnore]
        
        [Key]
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AlbumId { get; set; }
        public string TrackLink { get; set; } = default!;
        public string Photo { get; set; } = default!;
        public List<PlayListModel>? Playlists { get; set; }

        // public List<int>? PlaylistsId { get; set; }

    }
}
