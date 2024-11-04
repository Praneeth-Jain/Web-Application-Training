using System.ComponentModel.DataAnnotations;

namespace LoginPage.Data.Entity
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
