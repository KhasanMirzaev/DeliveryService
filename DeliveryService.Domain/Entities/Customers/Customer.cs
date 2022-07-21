using DeliveryService.Domain.Commons;
using DeliveryService.Domain.Entities.Orders;
using DeliveryService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Entities.Customers
{
    public class Customer : IAuditable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }


        public virtual ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

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
