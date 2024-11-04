using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace LoginPage.Data.Entity
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        public int Age { get; set; }


        public int isActive { get; set; } =  1;

        [Required,MaxLength(150)]
        public string ImgPath { get; set; }
    }
}
