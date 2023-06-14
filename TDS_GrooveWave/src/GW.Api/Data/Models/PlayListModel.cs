using System.ComponentModel.DataAnnotations;


namespace GW.Api.Data.Models
{
    public class PlayListModel
    {
        public PlayListModel() {}

        public PlayListModel(int id, int code, string name, bool isFavorite)
        {
            PlayListId = id;
            Name = name;
            IsFavorite = isFavorite;
            List<MusicModel> Musics = new List<MusicModel>();
        }
        [Key]
        public int PlayListId { get; set; }

        [Required(ErrorMessage = "O nome da playlist é obrigatório")]
        public string Name { get; set; } = default!;
        public int UserID {get; set;}
        public List<MusicModel> Musics { get; set; }

        public bool IsFavorite { get; set; }
    }
}
