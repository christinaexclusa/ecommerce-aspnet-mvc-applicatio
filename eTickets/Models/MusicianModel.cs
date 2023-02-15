using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class MusicianModel
	{
		[Key]
		public int Id { get; set; }
		public string  ProfilePictureURL { get; set; }
		public string FullName { get; set; }
		public string Band { get; set; }
		public string Bio { get; set; }

		public List<Musician_Band> Musicians_Bands { get; set; }
	}
}
