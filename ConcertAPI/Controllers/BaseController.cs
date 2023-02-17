using ConcertAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcertAPI.Controllers
{
 
    /// <summary>
    /// Base Generic API Web Controller
    /// </summary>
    /// <typeparam name="TEntity">Data Model to use</typeparam>
    [ApiController]
    public abstract class BaseController<TEntity> : ControllerBase
         where TEntity : class
    {
        protected readonly IRepository<TEntity> repository;
        private readonly ILogger logger;
        private readonly string className;

        /// <summary>
        /// Consturctor for the Base Controller
        /// </summary>
        /// <param name="repository">Repository to use</param>
        /// <param name="logger">Default Logger</param>
        public BaseController(IRepository<TEntity> repository,ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
            this.className = typeof(TEntity).Name.Replace("Model", "Controller");
            logger.LogInformation($"{className} started ");
        }

        /// <summary>
        /// Gets a list of TEntity based on Search Key
        /// </summary>
        /// <param name="pageIndex">int respenting the index</param>
        /// <param name="pageSize">Size of pages</param>
        /// <param name="orderByColumn">Order by column</param>
        /// <param name="keyColumn">Column to seach</param>
        /// <param name="searchText">Text to search for</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>List of TEntity</returns>
        [HttpGet("GetSearchPage")]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetSearchEntityAsync(
                                int pageIndex, 
                                int pageSize, 
                                string orderByColumn, 
                                string keyColumn, 
                                string searchText, 
                                CancellationToken cancellationToken = default)
        {
            List<TEntity> retValue;
            try
            {
                retValue = await this.repository.GetSearchEntityAsync(
                                                pageIndex, 
                                                pageSize, 
                                                orderByColumn,
                                                keyColumn,
                                                searchText, 
                                                cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Search All by page Failed");
                throw;
            }
            return retValue;
        }
        /// <summary>
        /// Get all TEntity based on Pageing
        /// </summary>
        /// <param name="pageIndex">int respenting the index</param>
        /// <param name="pageSize">Size of pages</param>
        /// <param name="orderByColumn">Order by column</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>List of TEntity</returns>
        [HttpGet("GetPage")]
        public virtual async Task<ActionResult<List<TEntity>>> GetAllPageAsync(int pageIndex,
                   int pageSize,
                   string orderByColumn = "Id",
                   CancellationToken cancellationToken = default)
        {
            List<TEntity> retValue = new();
            try
            {
                retValue = await this.repository.GetAllPageAsync(pageIndex, pageSize, orderByColumn, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Get All by page Failed");
                throw;
            }
            return retValue;
        }

        /// <summary>
        /// Uses a Linq Expression to find a list of TEntity
        /// </summary>
        /// <param name="predicate">Expression</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>List of TEntity</returns>
        [HttpGet("Find")]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            List<TEntity> retValue = new();
            try
            {
                retValue = await this.repository.FindAsync(predicate,cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Get All Failed");
                throw;
            }
            return retValue;
        }

        /// <summary>
        /// Gets all of the entities in the Table
        /// </summary>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>a list of Models</returns>
        /// <example>GET: api/BaseController</example>
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync(CancellationToken cancellationToken = default)
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

        /// <summary>
        /// Gets one TEntity based on Id
        /// </summary>
        /// <param name="id">int key value of row</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>TEntity</returns>
        /// <example>GET api/BaseController/5</example>
        [HttpGet("{id}")]
        public async virtual Task<ActionResult<TEntity>> GetAsync(int id, CancellationToken cancellationToken = default)
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

        /// <summary>
        /// Adds one Entity to the Database.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>TEntity</returns>
        /// <remarks>This issues a SaveChanges on the DbContext</remarks>
        /// <example>POST api/BaseController</example>
        [HttpPost]
        public async virtual Task<ActionResult<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            logger.LogInformation($"Add {className} Called with entity {entity}");
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

        /// <summary>
        /// Updates the TEntity 
        /// </summary>
        /// <param name="entity">TEntity</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async virtual Task<ActionResult<TEntity>> UpdateAsync(int id, TEntity entity, CancellationToken cancellationToken = default)
        {
            logger.LogInformation($"Update {className} Called with entity {entity}");
            try
            {
                entity = await this.repository.UpdateAsync(id, entity, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Update entity {entity} Failed");
                throw;
            }
            return entity;
        }


        /// <summary>
        /// Delete TEntity based on key int Id
        /// </summary>
        /// <param name="id">key int Id</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>true if successful </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            bool retValue = false;
            logger.LogInformation($"Delete {className} Called with Id {id}");
            try
            {
                TEntity entity = await this.repository.GetAsync(id);
                if (entity is null)
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
    }
}
