using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRMenu.EntityLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required, MaxLength(100)]
        public string ProductName { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
        public bool ProductStatus { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; } = default!;

        // BU SATIRI SİLİN veya yorum satırı yapın:
        // public List<OrderDetail> OrderDetails { get; set; }
    }
}
