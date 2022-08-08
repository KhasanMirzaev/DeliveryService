using DeliveryService.Domain.Entities.Compositions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Service.DTOs.Products
{
    public class ProductForCreationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameUz { get; set; }
        [Required]
        public string NameRu { get; set; }
        [Required]
        public string NameEn { get; set; }

        [Required]
        public string DescriptionUz { get; set; }
        [Required]
        public string DescriptionRu { get; set; }
        [Required]
        public string DescriptionEn { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid TimerCategoryId { get; set; }
        [Required]
        public ICollection<Composition> Compositions { get; set; }
    }
}
