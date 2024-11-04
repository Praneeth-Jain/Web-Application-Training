using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LoginPage.Pages.Product
{
    public class ProductModelcs
    {

        [Required]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public string ProductCategory { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }


        public int IsActive { get; set; }

        public int quantity { get; set; }

        public IFormFile ProductImage { get; set; }
    }
}
