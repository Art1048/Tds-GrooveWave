using System.ComponentModel.DataAnnotations;
using GW.Api.Data.Models.Shared;

namespace GW.Api.Data.Models
{
    public class PlayListModel : Entity
    {
        public PlayListModel() { }

        public PlayListModel(int id, int code, string name, bool isFavorite)
        {
            Id = id;
            Code = code;
            Name = name;
            IsFavorite = isFavorite;
        }
        public int Code { get; set; }

        [Required(ErrorMessage = "O nome da playlist é obrigatório")]
        public string Name { get; set; } = default!;
        public int UserID {get; set;}
        public List<MusicModel>? Musics { get; set; }

        public bool IsFavorite { get; set; }
    }
}
