using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.ILocalizations
{
    public interface ILocalizationName
    {
        string NameUz { get; set; }
        string NameRu { get; set; }
        string NameEn { get; set; }
    }
}
