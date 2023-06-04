using System.ComponentModel.DataAnnotations;
using Restaurant.Data.Data.Models.Shared;

namespace Restaurant.Data.Data.Models
{
    public class CategoryModel : Entity
    {
        public CategoryModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public CategoryModel() { }

        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Description { get; set; } = default!;

        public List<ProductModel>? Products { get; set; }
    }
};
