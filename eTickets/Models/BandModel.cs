using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class BandModel
	{
		//need a unique identifier
		[Key]
		public int Id { get; set; }
		public string ProfilePictureUrl { get; set; }
		public string FullName { get; set; }
		public string Genre { get; set; }
		public string Bio { get; set; }

		public List<MusicianModel> Bands { get; set; }
		public List<Musician_Band> Musicians_Bands { get; set; }
	}
}
