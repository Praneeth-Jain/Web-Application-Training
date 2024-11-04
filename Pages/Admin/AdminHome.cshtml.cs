using LoginPage.Data.Context;
using LoginPage.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginPage.Pages.Admin
{
    public class AdminHomeModel : PageModel
    {
        private readonly AppDbContext _context;

        public int id { get; set; }
        public List<Customer> CustomerList { get; set; }

        public AdminHomeModel(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("IsAdmin") == "Admin")
            {
                CustomerList = _context.customers.ToList();
                return Page();
            }
            else
            {
                TempData["Auth"] = "Only Admin Can Access this Page";
                return RedirectToPage("../Index");
            }

        }
        public IActionResult OnGetHandler(int? id, int? status)
        {
            CustomerList = _context.customers.ToList();
            var handleuser = _context.customers.Find(id);
            if (handleuser != null)
            {
                if (status == 0)
                {
                    handleuser.isActive = 1;
                }
                else
                {
                    handleuser.isActive = 0;
                }
                _context.SaveChanges();
            }
            return RedirectToPage();
        }

        public IActionResult OnGetDelete(int? id)
        {
            CustomerList = _context.customers.ToList();
            var Deleteuser = _context.customers.Find(id);
            if (Deleteuser != null)
            {
                _context.customers.Remove(Deleteuser);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }


    }
}
