namespace ConcertData.DataModels
{
    public interface IVenueModel
    {
        int Id { get; set; }
        string LogoURL { get; set; }
        string Name { get; set; }
    }
}