using System.ComponentModel.DataAnnotations;


namespace GW.Api.Data.Models
{
    public class PlayListModel
    {
        public PlayListModel() {}

        public PlayListModel(string name, bool isFavorite)
        {
            Name = name;
            IsFavorite = false;
        }
        [Key]
        public int PlayListId { get; set; }

        [Required(ErrorMessage = "O nome da playlist é obrigatório")]
        public string Name { get; set; } = default!;
        public int UserID {get; set;}
        public List<MusicModel>? Musics { get; set; }

        public bool IsFavorite { get; set; }
    }
}
