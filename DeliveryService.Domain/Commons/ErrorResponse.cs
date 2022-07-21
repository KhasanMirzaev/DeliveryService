using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Commons
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
