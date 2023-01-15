namespace Models.Entities;

public class Producer
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Bio { get; set; }
    public string ProfilePictureUrl { get; set; }

    public List<Movie> Movies { get; set; }
}
