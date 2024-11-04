using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginPage.Pages.SignupModel;
using LoginPage.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoginPage.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly AppDbContext _context;

        public SignUpModel(AppDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public SignupModelClass User { get; set; }
        public void OnGet()
        {
            Console.WriteLine(TempData["Message"]);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
            return Page();
            }
            
            var getUsers= _context.customers
                          .Where(x => x.Email == User.Username && x.Password==User.Password)
                          .FirstOrDefault();

            if (getUsers != null) {   
            TempData["Message"] = "Login Success";
            TempData["link"] = "/Index";
                //TempData["isLogin"] = "True";
            return RedirectToPage("Response");            
            }
            TempData["LoginError"] = "Account Dosent Exist please provide valid credentials";
            return Page();
        }
    }
}
