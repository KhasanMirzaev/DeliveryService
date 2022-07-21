using DeliveryService.Domain.Commons;
using DeliveryService.Domain.Entities.Customers;
using DeliveryService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Entities.Orders
{
    public class Order : IAuditable
    {
        public Guid Id { get; set; }
        public decimal Longitute { get; set; }
        public decimal Latitute { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }


        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


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
