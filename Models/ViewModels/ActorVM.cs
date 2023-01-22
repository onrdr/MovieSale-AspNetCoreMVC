using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels;

public class ActorVM
{
    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full Name is required")]
    public string FullName { get; set; }

    [Display(Name = "Biography")]
    [Required(ErrorMessage = "At least a short biography is required")]
    public string Bio { get; set; }


    [Display(Name = "Profile Picture")]
    [Required(ErrorMessage = "Profile Picture is required")]
    public string ProfilePictureUrl { get; set; }
}
