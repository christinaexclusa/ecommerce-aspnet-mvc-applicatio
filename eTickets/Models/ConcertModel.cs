using eTickets.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
	public class ConcertModel
	{
		
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string ImageURL { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public ConcertCategory ConcertCategory { get; set; }

		//Relationships
		public List<Musician_Band> Musician_Band { get; set; }

		//venue
		public int VenueId { get; set; }
		[ForeignKey("VenueId")]
		public VenueModel Venue { get; set; }

		//Band
		public int BandId { get; set; }
		[ForeignKey("BandId")]
		public BandModel Band { get; set; }

	}
}
