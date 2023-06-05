using System.ComponentModel.DataAnnotations;
using GW.Api.Data.Models.Shared;

namespace GW.Api.Data.Models
{
    public class UserModel : Entity
    {
        public UserModel() { }

        public UserModel(int id, string firstName, string lastName, string phone , string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Password = password;
        }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        public string LastName { get; set; } = default!;

        public string Phone { get; set; } = default!;

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "A Senha é obrigatório")]
        public string Password { get; set; } = default!;

        public List<PlayListModel>? PlayLists { get; set; }
        public PlayListModel? PlayListFavorita { get; set; }
    }
}
