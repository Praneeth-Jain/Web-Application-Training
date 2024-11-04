using LoginPage.Data.Context;
using LoginPage.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginPage.Pages
{
    public class EditPageModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        [BindProperty]
        public Customer MyCustomer { get; set; }

        [BindProperty]
        public IFormFile NewImage { get; set; }

        
        
        public EditPageModel(AppDbContext context,IWebHostEnvironment env)
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
        public void OnGetEditHandler(int? id)
        {
            Console.WriteLine(id);
            var editUser = _context.customers.Find(id);
            MyCustomer = editUser;
        }
        public IActionResult OnPostSave()
        {
            var SaveUser=_context.customers.Find(MyCustomer.Id);

            if(SaveUser != null)
            {
                if(NewImage != null)
                {
                    var filename = Guid.NewGuid().ToString() + Path.GetExtension(NewImage.FileName);
                    var filepath = Path.Combine(_env.WebRootPath, "uploads", filename);
                    var filestream = new FileStream(filepath, FileMode.Create);
                    NewImage.CopyToAsync(filestream);
                    SaveUser.ImgPath = filename;
                }
                SaveUser.Name = MyCustomer.Name;
                SaveUser.Email = MyCustomer.Email;
                SaveUser.Password = MyCustomer.Password;
                SaveUser.Age = MyCustomer.Age;
                _context.SaveChanges();
            }
            return RedirectToPage("/Admin/AdminHome");  
        }
        
    }
}
