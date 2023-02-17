using ConcertAPI.Context;
using ConcertAPI.Repositories.Interfaces;
using ConcertData.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcertAPI.Controllers
{
    /// <summary>
    /// Controller to handle all Band functions for the Table Bands
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : BaseController<BandModel>
    {
        private readonly ConcertContext context;

        /// <summary>
        /// Consturcture fdor Band Controller
        /// </summary>
        /// <param name="context">DB Context</param>
        /// <param name="repository">Band Repository</param>
        /// <param name="logger">Generic Logger</param>
        public BandController(ConcertContext context, IBandRepository repository,
                              ILogger<BandController> logger)
            : base(repository, logger)
        {
            this.context = context;
        }

        //[HttpGet]
        //public override async Task<ActionResult<IEnumerable<BandModel>>> GetAllAsync(CancellationToken cancellationToken = default)
        //{
        //    var retValue = await context.Bands
        //                        .SelectMany(b => b.Musicians)
        //                        .ToListAsync(cancellationToken);
        //    return retValue;
        //}
    }
}
