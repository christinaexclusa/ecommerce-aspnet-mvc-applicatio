using ConcertData.Enums;
using ConcertData.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcertData.DataModels
{
    /// <summary>
    /// Musicians that will play at the concert
    /// </summary>
    [Table("Musicians")]
    public class MusicianModel : PerformerModel, IPerformerModel
    {
        /// <summary>
        /// The type of  performer
        /// </summary>
        public override PerformerTypeEnum PerformerType => PerformerTypeEnum.Musician;
        /// <summary>
        /// List of bands the musician works for
        /// </summary>
        public virtual ICollection<BandModel>? Bands { get; set; }
    }
}

