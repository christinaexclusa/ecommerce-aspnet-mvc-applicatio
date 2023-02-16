using ConcertData.Enums;

namespace ConcertData.Interfaces
{
    /// <summary>
    /// Interface for performer
    /// </summary>
    public interface IPerformerModel
    {
        string? Bio { get; set; }
        string FullName { get; set; }
        int Id { get; set; }
        PerformerTypeEnum PerformerType { get; }
        GenreEnum PreformerCategory { get; set; }
        string ProfilePictureUrl { get; set; }
    }
}