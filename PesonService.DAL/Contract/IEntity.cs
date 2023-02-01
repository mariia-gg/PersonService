namespace PesonService.DAL.Contract
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime ModifiedAt { get; set; }
    }
}
