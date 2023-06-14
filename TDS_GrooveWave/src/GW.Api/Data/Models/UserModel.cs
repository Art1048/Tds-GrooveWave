using System.ComponentModel.DataAnnotations;

namespace GW.Api.Data.Models
{
    public class UserModel 
    {
        public UserModel() { }

        public UserModel( string firstName, string lastName, string? phone , string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Password = password;
        }

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        public string LastName { get; set; } = default!;

        public string? Phone { get; set; } = default!;

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "A Senha é obrigatório")]
        public string Password { get; set; } = default!;

        public List<PlayListModel>? PlayLists { get; set; }
        public PlayListModel? PlayListFavorita { get; set; }
    }
}
