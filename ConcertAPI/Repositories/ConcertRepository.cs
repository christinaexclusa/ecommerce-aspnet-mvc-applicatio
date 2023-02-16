using ConcertAPI.Context;
using ConcertAPI.Repositories.Interfaces;
using ConcertData.DataModels;

namespace ConcertAPI.Repositories
{
    public class ConcertRepository 
        : Repository<ConcertModel>, IConcertRepository
    {
        public ConcertRepository(ConcertContext context, ILogger<ConcertRepository> logger)
            : base(context, logger)
        {

        }
    }
}
