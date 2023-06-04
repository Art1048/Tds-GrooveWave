using System.ComponentModel.DataAnnotations;
using Restaurant.Data.Data.Models.Shared;

namespace Restaurant.Data.Data.Models
{
    public class TableModel : Entity
    {
        public TableModel() { }

        public TableModel(int id, int code, bool status, DateTime? startAt)
        {
            Id = id;
            Code = code;
            Status = status;
            StartAt = startAt;
        }

        [Required(ErrorMessage = "O código da mesa é obrigatório")]
        public int Code { get; set; }
        public bool Status { get; set; } = default!;
        public DateTime? StartAt { get; set; } = default!;

        public List<ServiceModel>? Services { get; set; }
    }
}
