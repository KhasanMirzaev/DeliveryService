using DeliveryService.Domain.Commons;
using DeliveryService.Domain.Entities.Categories;
using DeliveryService.Domain.Entities.Compositions;
using DeliveryService.Domain.Entities.Orders;
using DeliveryService.Domain.Entities.TimeCategories;
using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ILocalizations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DeliveryService.Domain.Entities.Products
{
    public class Product : IAuditable, ILocalizationName, ILocalizationDescription
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

        [NotMapped]
        public string Description { get; set; }
        public string DescriptionUz { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionEn { get; set; }


        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }


        [ForeignKey(nameof(TimeCategory))]
        public Guid TimeCategoryId { get; set; }
        [JsonIgnore]
        public virtual TimeCategory TimeCategory { get; set; }

        [ForeignKey(nameof(Composition))]
        public Guid CompositionId { get; set; }
        [JsonIgnore]
        public virtual Composition Composition { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        //Constructor
        public Product()
        {
            OrderDetails = new List<OrderDetails>();
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
