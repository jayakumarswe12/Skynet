using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Product:BaseEntity
    { 
        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int PictureUrl { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public int ProductBrandId { get; set; }
    }
}