using System.Text.Json.Serialization;
using Restaurant.Data.Data.Models.Shared;

namespace Restaurant.Data.Data.Models
{
    public class ServiceModel : Entity
    {
        public ServiceModel() { }

        public ServiceModel(int tableId, DateTime StartAt, DateTime? EndAt)
        {
            this.TableId = tableId;
            this.StartAt = StartAt;
            this.EndAt = EndAt;
        }
        [JsonIgnore]
        public int TableId { get; set; }
        public DateTime StartAt { get; set; } = default!;

        public DateTime? EndAt { get; set; } = default!;

        public TableModel? Table { get; set; }
        public List<ServiceLineModel>? ServiceLines { get; set; }
    }
}
