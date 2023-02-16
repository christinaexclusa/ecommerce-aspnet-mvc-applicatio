using ConcertAPI.Repositories.Interfaces;
using ConcertData.DataModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertController : BaseController<ConcertModel>
    {
        public ConcertController(IConcertRepository repository, ILogger<ConcertController> logger)
            : base(repository, logger)
        {

        }
    }
}
