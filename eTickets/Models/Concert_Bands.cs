using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Concert_Bands
	{
		[Key]
		public int BandId { get; set; }
		public BandModel Band { get; set; }
		public int ConcertID { get; set; }

	}
}
