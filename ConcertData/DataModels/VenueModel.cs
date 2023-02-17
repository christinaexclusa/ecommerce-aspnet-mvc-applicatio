using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConcertData.DataModels
{
    /// <summary>
    /// Table for venues
    /// </summary>
    [Table("Venues")]
    public class VenueModel : IVenueModel
    {
        /// <summary>
        /// Table key value
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// URL for the Logo
        /// </summary>
        [Required]
        [StringLength(500)]
        [Url]
        public string LogoURL { get; set; } = null!;

        /// <summary>
        /// Name of the Venue
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Concert collection
        /// </summary>
        // one to many relationship
        public virtual ICollection<ConcertModel>? Concerts { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
