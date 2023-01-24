using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels;

public class CinemaVM
{
    [Display(Name = "Cinema Name")]
    [Required(ErrorMessage = "Ciname name is required")]
    public string Name { get; set; }

    [Display(Name = "Description")]
    [Required(ErrorMessage = "At least a short description is required")]
    public string Description { get; set; }

    [Display(Name = "Cinema Logo")]
    [Required(ErrorMessage = "Cinema logo is required")]
    public string Logo { get; set; } 
}