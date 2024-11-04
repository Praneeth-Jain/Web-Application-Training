using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LoginPage.Pages.Shared.RegisterModelClass
{
    public class RegisterModelClass
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(10)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(0,100)]
        public int Age { get; set; }

        [Required]
        public string SelectGender { get; set; }


        public List<SelectListItem> Gender { get; set; }=new List<SelectListItem>();

        
        public IFormFile Image { get; set; }



    }
}
