using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Musician_Band
	{
		
		public int BandId { get; set; }
		public BandModel Band { get; set; }
		public int MusicianId { get; set; }
		public MusicianModel Musician { get; set; }
		
	}
}
