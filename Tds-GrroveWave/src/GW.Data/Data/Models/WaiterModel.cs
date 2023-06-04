using System.ComponentModel.DataAnnotations;
using Restaurant.Data.Data.Models.Shared;

namespace Restaurant.Data.Data.Models
{
    public class WaiterModel : Entity
    {
        public WaiterModel() { }

        public WaiterModel(int id, int code, string firstName, string lastName, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Code = code;
            Phone = phone;
        }

        [Required(ErrorMessage = "O nome do garçom é obrigatório")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "O sobrenome do garçom é obrigatório")]
        public string LastName { get; set; } = default!;

        [Required(ErrorMessage = "A matrícula do garçom é obrigatória")]
        public int Code { get; set; } = default!;

        [Required(ErrorMessage = "O telefone do garçom é obrigatório")]
        public string Phone { get; set; } = default!;
    }
}
