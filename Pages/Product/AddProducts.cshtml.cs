using LoginPage.Data.Context;
using LoginPage.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginPage.Pages.Product
{
    public class AddProductsModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        [BindProperty]
        public ProductModelcs product { get; set; }

        public AddProductsModel(AppDbContext context,IWebHostEnvironment env) 
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("IsAdmin") == "Admin")
            {
                return Page();
            }
            else
            {
                TempData["Auth"] = "Only Admin Can Access this Page";
                return RedirectToPage("Index");
            }
        }

        public IActionResult OnPostAddProduct()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(product.ProductImage.FileName);
            var filepath = Path.Combine(_env.WebRootPath,"productImg",filename);
            var filestream=new FileStream(filepath,FileMode.Create);
            product.ProductImage.CopyToAsync(filestream);
            var newProd = new Products { 
                ProductName=product.ProductName,
                ProductDescription=product.ProductDescription,
                ProductCategoryName=product.ProductCategory,
                ProductPrice=product.ProductPrice,
                Quantity=product.quantity,
                ProductImgPath=filename
            };
            _context.products.Add(newProd);
            _context.SaveChanges();
            TempData["ProductsMsg"] = "Product Added Successfully";
            return RedirectToPage("/Product/Index");   
        }
    }
}
