using DeliveryService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Commons
{
    public interface IAuditable
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        Guid? UpdatedBy { get; set; }
        ItemState State { get; set; }
    }
}
