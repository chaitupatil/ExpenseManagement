using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please enter your First Name")]
        [MinLength(3,ErrorMessage ="First Name is TOO SHORT")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        [MinLength(3, ErrorMessage = "Last Name is TOO SHORT")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Email Address")]
        [MinLength(3, ErrorMessage = "Email Address is TOO SHORT")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }

    }
}
