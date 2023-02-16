using ConcertData.Enums;
using ConcertData.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcertData.DataModels
{
    /// <summary>
    /// Bands that will play at a concert
    /// </summary>
    [Table("Bands")]
    public class BandModel : IPerformerModel
    {
        /// <summary>
        /// Id Key field the Bands
        /// </summary>
        [Key]
        public int Id { get; set; }
               

        /// <summary>
        /// Picture URL the Bands 
        /// </summary>
        [Required]
        [StringLength(500)]
        [Url]
        public string ProfilePictureUrl { get; set; } = null!;

        /// <summary>
        /// Full Name of the Bands
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Genre of the Bands
        /// </summary>
        [Required]
        public GenreEnum PreformerCategory { get; set; }

        /// <summary>
        /// The Bio of theBands
        /// </summary>
        [StringLength(500)]
        public string? Bio { get; set; }

        /// <summary>
        /// The type of performer
        /// </summary>
        public PerformerTypeEnum PerformerType => PerformerTypeEnum.Band;

        /// <summary>
        /// The musician in the band
        /// </summary>
        public ICollection<MusicianModel> Musicians { get; set; } = null!;
    }
}