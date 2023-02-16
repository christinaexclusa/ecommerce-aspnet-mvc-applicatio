using ConcertData.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertData.DataTransfer
{
    public class ConcertDTO : ConcertModel
    {
        /// <summary>
        /// Venue URL for the Logo
        /// </summary>
        [Required]
        [Url]
        public string LogoURL { get; set; } = null!;

        /// <summary>
        /// Name of the Venue
        /// </summary>
        [Required]
        [StringLength(100)]
        public string VenueName { get; set; } = null!;
    }
}
