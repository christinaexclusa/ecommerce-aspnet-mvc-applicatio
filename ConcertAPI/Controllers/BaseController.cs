using ConcertAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcertAPI.Controllers
{
   
    [ApiController]
    public abstract class BaseController<TEntity> : ControllerBase
         where TEntity : class
    {
        protected readonly IRepository<TEntity> repository;
        private readonly ILogger logger;

        public BaseController(IRepository<TEntity> repository,ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        // GET: api/<BaseController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            List<TEntity> retValue = new();
            try
            {
                retValue = await this.repository.GetAllAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Get All Failed");
                throw;
            }
            return retValue;
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            TEntity entity;
            try
            {
                entity = await this.repository.GetAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Get by Id {id} Failed");
                throw;
            }
            return entity;
        }

        // POST api/<BaseController>
        [HttpPost]
        public async Task<ActionResult<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                entity = await this.repository.AddAsync(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Add entity {entity.ToString()} Failed");
                throw;
            }
            return entity;
        }

        // PUT api/<BaseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                entity = await this.repository.UpdateAsync(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Update entity {entity.ToString()} Failed");
                throw;
            }
            return entity;
        }

        // DELETE api/<BaseController>/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            bool retValue = false;
            try
            {
                await this.repository.DeleteAsync(entity, cancellationToken);
                retValue = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Delete entity {entity.ToString()} Failed");
                throw;
            }
            return retValue;
        }
        [HttpDelete("id")]
        public async Task<ActionResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            bool retValue = false;
            try
            {
                TEntity entity = await this.repository.GetAsync(id);
                if(entity is null)
                {
                    throw new ApplicationException($"Unable to find Id {id} to delete");
                }
                await this.repository.DeleteAsync(entity, cancellationToken);
                retValue = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Update entity by id {id} Failed");
                throw;
            }
            return retValue;
        }
        public async virtual Task<int> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            int changes = 0;
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            return changes;
        }
    }
}
