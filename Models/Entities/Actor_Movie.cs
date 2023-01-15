namespace Models.Entities;

public class Actor_Movie
{
    public int MovieId { get; set; }
    public Movie Movie { get; set; }

    public Actor Actor { get; set; }
    public int ActorId { get; set; }
}
