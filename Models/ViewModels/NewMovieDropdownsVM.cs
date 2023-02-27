using Models.Entities;

namespace Models.ViewModels;

public class NewMovieDropdownsVM
{
    public NewMovieDropdownsVM()
    {
        Producers = new();
        Cinemas = new();
        Actors = new();
    }

    public List<Producer> Producers { get; set; }
    public List<Cinema> Cinemas { get; set; }
    public List<Actor> Actors { get; set; }
}
