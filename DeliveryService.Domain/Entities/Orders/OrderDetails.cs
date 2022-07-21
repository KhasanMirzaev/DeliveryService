using DeliveryService.Domain.Commons;
using DeliveryService.Domain.Entities.Products;
using DeliveryService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Entities.Orders
{
    public class OrderDetails : IAuditable
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }


        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }


        public void Create()
        {
            CreatedDate = DateTime.Now;
            State = ItemState.Created;
        }

        public void Update()
        {
            UpdatedDate = DateTime.Now;
            State = ItemState.Updated;
        }

        public void Delete()
        {
            State = ItemState.Deleted;
        }
    }
}
