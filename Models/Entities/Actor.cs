using Models.Entities.Abstract;

namespace Models.Entities;

public class Actor : IEntityBase
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Bio { get; set; }
    public string ProfilePictureUrl { get; set; }

    public List<Actor_Movie> Actors_Movies { get; set; }
}
