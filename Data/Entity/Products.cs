using System.ComponentModel.DataAnnotations;

namespace LoginPage.Data.Entity
{
    public class Products
    {
        [Key]
        public int PId { get; set; }

        [Required]
        public string ProductName { get; set; }


        [MaxLength(200)]
        public string ProductDescription { get; set; }


        public string ProductCategoryName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public int isActive { get; set; } = 1;

        public string ProductImgPath { get; set; }
    
    }
}
