using ConcertData.Enums;
using ConcertData.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcertData.DataModels
{
    /// <summary>
    /// Bands that will play at a concert
    /// </summary>
    [Table("Bands")]
    public class BandModel : PerformerModel, IPerformerModel
    {
        /// <summary>
        /// The type of  performer
        /// </summary>
        public override PerformerTypeEnum PerformerType => PerformerTypeEnum.Band;

        /// <summary>
        /// The musician in the band
        /// </summary>
        public ICollection<MusicianModel> Musicians { get; set; } = null!;
    }
}