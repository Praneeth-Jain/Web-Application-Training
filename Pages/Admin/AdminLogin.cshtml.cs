using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoginPage.Pages.Admin
{
    public class AdminLoginModel : PageModel
    {
        [BindProperty]
        public string AdminUsername { get; set; }
        [BindProperty]
        public string AdminPassword { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (AdminUsername == "admin" && AdminPassword == "admin")
            {
                TempData["Message"] = "Admin Login Success";
                TempData["link"] = "Admin/AdminHome";
                TempData["LoginError"] = "Admin Account Dosent Exist please provide valid credentials";
                HttpContext.Session.SetString("IsAdmin", "Admin");
                return RedirectToPage("../Response");
            }


            return Page();

            //TempData["isLogin"] = "True";
        }
    }
}
