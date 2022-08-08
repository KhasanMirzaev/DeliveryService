using DeliveryService.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Service.DTOs.Ordrers
{
    public class OrderForCreationDto
    {
        [Required]
        public decimal Longitute { get; set; }
        [Required]
        public decimal Latitute { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public IList<OrderDetails> Details { get; set; }
    }
}
