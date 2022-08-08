using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Service.DTOs.Compositions
{
    public class CompositionForCreationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameUz { get; set; }
        [Required]
        public string NameRu { get; set; }
        [Required]
        public string NameEn { get; set; }
    }
}
