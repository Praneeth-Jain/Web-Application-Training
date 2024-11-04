using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoginPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string CourseList { get; set; }

        public List<SelectListItem> Course { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Course = new List<SelectListItem>
            {
                new SelectListItem{Value = "one", Text = "Option 1" },
                new SelectListItem{Value = "two", Text = "Option 2" },
                new SelectListItem{Value = "Three", Text = "Option 3" }
            };

            //if (TempData["isLogin"] == null)
            //{
            //    return RedirectToPage("/Signup");
            //}
            //return Page();

        }
    }
}
