namespace TheWindCorner.Data.Models.Entities.Contracts
{
    

    public interface INotifiableEntity
    {
        Guid Id { get; }
        DateTime DateAdded { get; }

    }
}
