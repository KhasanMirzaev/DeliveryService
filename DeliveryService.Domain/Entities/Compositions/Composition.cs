using DeliveryService.Domain.Commons;
using DeliveryService.Domain.Entities.Products;
using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ILocalizations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Entities.Compositions
{
    public class Composition : IAuditable, ILocalizationName
    {
        public Guid Id { get; set; }

        [NotMapped]
        public string Name { get; set; }
        [JsonIgnore]
        public string NameUz { get; set; }
        [JsonIgnore]
        public string NameRu { get; set; }
        [JsonIgnore]
        public string NameEn { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        //Constructor
        public Composition()
        {
            Products = new List<Product>();
        }

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
