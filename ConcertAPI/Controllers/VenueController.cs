using ConcertAPI.Context;
using ConcertAPI.Repositories.Interfaces;
using ConcertData.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcertAPI.Controllers
{
    /// <summary>
    /// Venue Controller for EF operations aginst the Venue Table
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : BaseController<VenueModel>
    {
        private readonly ConcertContext context;
        private readonly ILogger<VenueController> logger;

        /// <summary>
        /// Venue Consturcture
        /// </summary>
        /// <param name="context">DBContext</param>
        /// <param name="repository">Repository Generic</param>
        /// <param name="logger">Default Logger</param>
        public VenueController(ConcertContext context, IVenueRepository repository, ILogger<VenueController> logger)
            : base(repository, logger)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets all the Venues in the Table
        /// </summary>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>List of Venues</returns>
        [HttpGet("GetAllAsync")]
        public override async Task<ActionResult<IEnumerable<VenueModel>>> GetAllAsync(CancellationToken cancellationToken = default)
        {

            List<VenueModel> retValue;
            try
            {
                retValue = await context.Venues
                         .AsNoTracking()
                         .OrderBy(v => v.Name)
                         .Select(v => new VenueModel
                         {
                             Id = v.Id,
                             Name = v.Name,
                             LogoURL = v.LogoURL,
                             Concerts = v.Concerts.Select(c => new ConcertModel
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 Description = c.Description,
                                 ImageURL = c.ImageURL,
                                 Price = c.Price,
                                 ConcertDate = c.ConcertDate,
                                 ConcertGenre = c.ConcertGenre
                             }).ToList()
                         }).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Get All Venues Failed");
                throw;
            }
            return retValue;
        }
        /// <summary>
        /// Gets one Venue based on Id
        /// </summary>
        /// <param name="id">int key value of row</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>TEntity</returns>
        /// <example>GET api/Venue/5</example>
        [HttpGet("{id}")]
        public override async Task<ActionResult<VenueModel>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            VenueModel? entity;
            try
            {
                entity = await context.Venues
                        .AsNoTracking()
                        .Where(v=>v.Id == id)
                        .Select(v => new VenueModel
                        {
                            Id = v.Id,
                            Name = v.Name,
                            LogoURL = v.LogoURL,
                            Concerts = v.Concerts.Select(c => new ConcertModel
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Description = c.Description,
                                ImageURL = c.ImageURL,
                                Price = c.Price,
                                ConcertDate = c.ConcertDate,
                                ConcertGenre = c.ConcertGenre
                            }).ToList()
                        }).FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Get Venue by Id {id} Failed");
                throw;
            }
            return entity;
        }
    }
}
