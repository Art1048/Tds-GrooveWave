using System.Text.Json.Serialization;
using Restaurant.Data.Data.Models.Shared;

namespace Restaurant.Data.Data.Models
{
    public class ServiceLineModel : Entity
    {
        public ServiceLineModel(
            int serviceId,
            int tableId,
            int waiterId,
            int productId,
            int Quantity
        )
        {
            this.ServiceId = serviceId;
            this.TableId = tableId;
            this.WaiterId = waiterId;
            this.ProductId = productId;
            this.Quantity = Quantity;
        }

        [JsonIgnore]
        public int ServiceId { get; set; }

        [JsonIgnore]
        public ServiceModel? Service { get; set; }

        [JsonIgnore]
        public int TableId { get; set; }

        [JsonIgnore]
        public TableModel? Table { get; set; }

        [JsonIgnore]
        public int ProductId { get; set; }
        public ProductModel? Product { get; set; }

        [JsonIgnore]
        public int WaiterId { get; set; }
        public WaiterModel? Waiter { get; set; }
        public int Quantity { get; set; }
    }
}
