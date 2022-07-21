using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.ILocalizations
{
    public interface ILocalizationDescription
    {
        string DescriptionUz { get; set; }
        string DescriptionRu { get; set; }
        string DescriptionEn { get; set; }
    }
}
