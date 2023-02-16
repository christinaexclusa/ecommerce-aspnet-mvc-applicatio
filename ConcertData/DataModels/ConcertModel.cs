using ConcertData.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcertData.Interfaces;

namespace ConcertData.DataModels
{
    /// <summary>
    /// Repersents a Data Table 
    /// </summary>
    [Table("Concerts")]
    public class ConcertModel
    {
        /// <summary>
        /// Key Id for Concert
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Foreign Key to venue
        /// </summary>
        // one to one relationship
        [ForeignKey("Venue")]
        public int VenueId { get; set; }

        /// <summary>
        /// Venue for the concert
        /// </summary>
        public virtual VenueModel? Venue { get; set; }


        /// <summary>
        /// Name for the concert
        /// </summary>
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description for the Concert
        /// </summary>
        [StringLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// Price for the concert
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// Image URL
        /// </summary>
        [Required]
        [StringLength(500)]
        [Url]
        public string ImageURL { get; set; } = null!;

        /// <summary>
        /// Concert Date and time
        /// </summary>
        [Required]
        public DateTime ConcertDate { get; set; }

        /// <summary>
        /// Concert Genre
        /// </summary>
        public GenreEnum ConcertGenre { get; set; }

        /// <summary>
        /// Collection of Performers
        /// </summary>
         [NotMapped]
        public virtual ICollection<IPerformerModel> Performers { get; set; } = null!;
    }
}
