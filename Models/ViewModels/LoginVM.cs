using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels;

public class LoginVM
{
    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email adress is required")]
    public string EmailAddress { get; set; }
     
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}