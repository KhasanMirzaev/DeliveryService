using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Service.Interfaces
{
    public interface IFileSevice
    {
        Task<string> SaveFileAsync(Stream file, string fileName);
    }
}
