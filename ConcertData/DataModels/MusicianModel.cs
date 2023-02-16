using ConcertData.Enums;
using ConcertData.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcertData.DataModels
{
    /// <summary>
    /// Musicians that will play at the concert
    /// </summary>
    [Table("Musicians")]
    public class MusicianModel : IPerformerModel
    {
        /// <summary>
        /// Id Key field the Musicians
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Picture URL the Musicians
        /// </summary>
        [Required]
        [StringLength(500)]
        [Url]
        public string ProfilePictureUrl { get; set; } = null!;

        /// <summary>
        /// Full Name of the Musicians
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Genre of the Musicians
        /// </summary>
        [Required]
        public GenreEnum PreformerCategory { get; set; }

        /// <summary>
        /// The Bio of the Musicians 
        /// </summary>
        [StringLength(500)]
        public string? Bio { get; set; }

        /// <summary>
        /// The type of  performer
        /// </summary>
        public PerformerTypeEnum PerformerType => PerformerTypeEnum.Musician;

        /// <summary>
        /// List of bands the musician works for
        /// </summary>
        public virtual ICollection<BandModel>? Bands { get; set; }
    }
}

