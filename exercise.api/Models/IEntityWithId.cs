namespace exercise.api.Models
{
    public interface IEntityWithId
    {
        int Id { get; set; }
    }
}
// created this interface because I think ef has troubles trnaslating linq to get the id into sql