using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using LoginPage.Pages.Shared.RegisterModelClass;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoginPage.Data.Context;
using LoginPage.Data.Entity;


namespace LoginPage.Pages
{
    public class RegisterModel : PageModel
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public RegisterModel(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }



        [BindProperty]
        public RegisterModelClass RegistredUser { get; set; }

        public void PopulateOptions()
        {
            if (RegistredUser == null)
            {
                RegistredUser = new RegisterModelClass();
            }

            RegistredUser.Gender = new List<SelectListItem> {
             new SelectListItem {Value="M",Text="Male"},
             new SelectListItem {Value="F",Text="Female"},
             new SelectListItem {Value="O",Text="Others"},
            };
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(RegistredUser.Image.FileName);
            var filePath = Path.Combine(_environment.WebRootPath,"uploads",fileName);
            var FileStream=new FileStream(filePath, FileMode.Create);
            RegistredUser.Image.CopyToAsync(FileStream);

            
            var newCus = new Customer
            {
                Name = RegistredUser.Username,
                Email = RegistredUser.Email,
                Password = RegistredUser.Password,
                Age = RegistredUser.Age,
                ImgPath = fileName
            }; 
            _context.customers.Add(newCus);
            _context.SaveChanges();
            TempData["Message"] = "Account Created Successfully";
            TempData["link"] = "/Signup";
            return RedirectToPage("Response");
        }

        public void OnGet()
        {
            PopulateOptions();
        }

    }
}


