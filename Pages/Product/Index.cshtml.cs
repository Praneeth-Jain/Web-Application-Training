using LoginPage.Data.Context;
using LoginPage.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginPage.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public int id { get; set; }
        public List<Products> ProductList { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            ProductList=_context.products.ToList();
        }
        public IActionResult OnGetDeleteProduct(int? id)
        {
            ProductList=_context.products.ToList();
            var deleteProduct = _context.products.Find(id);
            if (deleteProduct != null)
            {
                _context.products.Remove(deleteProduct);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
