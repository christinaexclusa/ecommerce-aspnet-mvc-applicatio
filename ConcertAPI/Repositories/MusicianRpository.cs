using ConcertAPI.Context;
using ConcertAPI.Repositories.Interfaces;
using ConcertData.DataModels;

namespace ConcertAPI.Repositories
{
    public class MusicianRpository
        : Repository<MusicianModel>, IMusicianRepository
    {
        public MusicianRpository(ConcertContext context, ILogger<MusicianRpository> logger)
            : base(context, logger)
        {

        }
    }
}
