using eTickets.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eTickets.Data
{
	public class eTicketDbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<ConcertContext>();
				//if there are no venues
				if (!context.Venues.Any())
				{
					new VenueModel()
					{
						Name = "Venue 1",
						Logo = "https://acousticbridge.com/wp-content/uploads/2021/11/Concert-ukulele-vs-tenor_2000x1250.jpg",
						Description = "Description of Venue 1"
					};
					new VenueModel()
					{
						Name = "Venue 2",
						Logo = "https://acousticbridge.com/wp-content/uploads/2021/11/Concert-ukulele-vs-tenor_2000x1250.jpg",
						Description = "Description of Venue 2"
					};

				}
				if (!context.Musicians.Any())
				{
					new MusicianModel()
					{
						FullName = "Musician 1",
						Band = "Band",
						Bio = "Bio for 1"

					};
				}
				if (!context.Bands.Any())
				{

				}
				if (!context.Concerts.Any())
				{

				}
				if (!context.Musician_Band.Any())
				{

				}
			}
		}
	}
}
