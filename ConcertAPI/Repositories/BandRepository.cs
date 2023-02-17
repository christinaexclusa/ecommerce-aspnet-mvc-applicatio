using ConcertAPI.Context;
using ConcertAPI.Repositories.Interfaces;
using ConcertData.DataModels;
using Microsoft.Extensions.Logging;

namespace ConcertAPI.Repositories
{
    public class BandRepository 
        : Repository<BandModel>, IBandRepository
    {
        public BandRepository(ConcertContext context, ILogger<BandRepository> logger)
            : base(context,logger)
        {

        }
    }
}
