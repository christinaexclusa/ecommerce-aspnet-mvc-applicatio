using ConcertAPI.Context;
using ConcertAPI.Repositories.Interfaces;
using ConcertData.DataModels;

namespace ConcertAPI.Repositories
{
    public class VenueRepository 
        : Repository<VenueModel>, IVenueRepository
    {
        public VenueRepository(ConcertContext context, ILogger<VenueRepository> logger)
            : base(context, logger)
        {

        }
    }
}
