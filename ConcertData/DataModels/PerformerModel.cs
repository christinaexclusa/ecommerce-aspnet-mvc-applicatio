using ConcertData.Enums;
using ConcertData.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcertData.DataModels
{
    /// <summary>
    /// This class is used to get all the Musicians and the Bands
    /// </summary>
    [Table("Performers")]
    public abstract class PerformerModel : IPerformerModel
    {
        /// <summary>
        /// Id Key field the Musicians and the Bands
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Type of performer
        /// </summary>
        public abstract PerformerTypeEnum PerformerType { get; }

        /// <summary>
        /// Picture URL the Musicians and the Bands 
        /// </summary>
        [Required]
        [StringLength(500)]
        [Url]
        public string ProfilePictureUrl { get; set; } = null!;

        /// <summary>
        /// Full Name of the Musicians and the Bands
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Genre of the Musicians and the Bands
        /// </summary>
        [Required]
        public GenreEnum PreformerCategory { get; set; }

        /// <summary>
        /// The Bio of the Musicians and the Bands
        /// </summary>
        [StringLength(500)]
        public string? Bio { get; set; }
    }
}

