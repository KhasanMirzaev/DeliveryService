using DeliveryService.Domain.Commons;
using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ILocalizations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Domain.Entities.Products
{
    public class Product : IAuditable, ILocalizationName, ILocalizationDescription
    {
        public Guid Id { get; set; }

        [NotMapped]
        public string Name { get; set; }
        public string NameUz { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }

        [NotMapped]
        public string Description { get; set; }
        public string DescriptionUz { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionEn { get; set; }

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
