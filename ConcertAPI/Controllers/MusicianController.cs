using ConcertAPI.Repositories.Interfaces;
using ConcertData.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : BaseController<MusicianModel>
    {
        public MusicianController(IMusicianRepository repository, ILogger<MusicianController> logger)
            : base(repository, logger)
        {

        }
    }
}
