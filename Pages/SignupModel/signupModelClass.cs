using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LoginPage.Pages.SignupModel
{
    public class SignupModelClass
    {
        [Required]
        [EmailAddress(ErrorMessage ="Enter valid Email Address")]
        
        public string Username { get; set; }

        [Required(ErrorMessage ="Password please :(")]
        public string Password { get; set; }



    }
}
