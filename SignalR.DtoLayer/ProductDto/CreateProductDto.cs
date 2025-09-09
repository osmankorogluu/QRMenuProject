using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.ProductDto
{
    public class CreateProductDto
    {
        //public string ProductName { get; set; }
        //public string Description { get; set; }
        //public decimal Price { get; set; }
        //public string ImageUrl { get; set; }
        //public bool ProductStatus { get; set; }

        [Required, MaxLength(100)]
        public string ProductName { get; set; } = default!;
        [Required] public decimal Price { get; set; }
        [Required] public string Description { get; set; } = default!; // NULL hatasını da engeller
        public string? ImageUrl { get; set; }
        public bool ProductStatus { get; set; } = true;

        [Required] public int CategoryId { get; set; }   // <-- EKLE


    }
}
