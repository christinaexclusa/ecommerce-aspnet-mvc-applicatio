using ConcertAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
/// <summary>
/// Generic Respository to Handle ENtity Frame work Database Tables.
/// </summary>
/// <typeparam name="TEntity">Data Model.</typeparam>
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext dbContext;
    private readonly ILogger<Repository<TEntity>> logger;
    private readonly string? className;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
    /// </summary>
    /// <param name="dbContext">Entity Frame Work DBContext.</param>
    /// <param name="logger">Logger interface.</param>
    public Repository(DbContext dbContext, ILogger<Repository<TEntity>> logger)
    {
        this.dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.className = typeof(TEntity).FullName;
    }

    /// <summary>
    /// Add a TEntity to the Database Async.
    /// </summary>
    /// <param name="entity">Data Model TEntity.</param>
    /// <param name="cancellationToken">cancellationToken.</param>
    /// <returns>The New Data Model.</returns>
    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity = entity ?? throw new System.ArgumentNullException(nameof(entity));
        try
        {
            await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            dbContext.Entry(entity).State = EntityState.Detached;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Failed to add {className} Entity to database.");
            throw;
        }

        return entity;
    }

    /// <summary>
    /// Add a TEntity to the Database.
    /// </summary>
    /// <param name="entity">Data Model TEntity.</param>
    /// <param name="cancellationToken">cancellationToken.</param>
    /// <returns>Updated Data Model.</returns>
    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity = entity ?? throw new System.ArgumentNullException(nameof(entity));
        try
        {
            await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync(cancellationToken);
            dbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Failed to add {className} Entity to database.");
            throw;
        }
    }

    /// <summary>
    /// Marks a record for deletion and Updates the Entity in the Database.
    /// </summary>
    /// <param name="entity">Data Model TEntity.</param>
    /// <param name="cancellationToken">cancellationToken.</param>
    /// <returns>True if successful.</returns>
    public async virtual Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        bool retValue = false;
        entity = entity ?? throw new System.ArgumentNullException(nameof(entity));
        try
        {
            if (entity != null)
            {
                dbContext.Remove(entity);
                await dbContext.SaveChangesAsync(cancellationToken);
                retValue = true;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Failed to Delete {className} Entity in database.");
            throw;
        }

        return retValue;
    }

    /// <summary>
    /// Adds a List of TEntity Data Model.
    /// </summary>
    /// <param name="entities"> List of TEntity's.</param>
    /// <param name="cancellationToken">cancellationToken.</param>
    /// <returns>an int.</returns>
    public async virtual Task<int> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        int retValue;
        entities = entities ?? throw new System.ArgumentNullException(nameof(entities));
        try
        {
            await dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            retValue = await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Failed to addRange {className} Entities to database.");
            throw;
        }

        return retValue;
    }

    /// <summary>
    /// Returns a list of TEntities based of LinQ Expression.
    /// </summary>
    /// <param name="predicate">Expression.</param>
    /// <param name="cancellationToken">cancellationToken.</param>
    /// <returns>List of TEntity.</returns>
    public virtual async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        try
        {
            return await dbContext.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Failed to Find {className} Entity in database.");
            throw;
        }
    }

    /// <summary>
    /// Gets a Data model based on ID.
    /// </summary>
    /// <param name="id">Id key field.</param>
    /// <param name="cancellationToken">cancellationToken.</param>
    /// <returns>Data Model.</returns>
    /// <remarks>No Tracking is uesd on the results set for the Entity.</remarks>
    public virtual async Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        TEntity? retValue;
        try
        {
            retValue = await dbContext.Set<TEntity>()
             .Where(w => EF.Property<int>(w, "Id") == id)
             .FirstOrDefaultAsync(cancellationToken);

            if (retValue == null)
            {
                throw new Exception($"Failed to find {id} in {className} Table.");
            }

            dbContext.Entry(retValue).State = EntityState.Detached;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Failed to Get {className} Entity from database.");
            throw;
        }

        return retValue;
    }

    /// <summary>
    /// Gets all Data Model TEntity.
    /// </summary>
    /// <param name="cancellationToken">cancellationToken.</param>
    /// <returns>List of Data Models TEntity.</returns>
    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<TEntity> retValue;
        try
        {

            retValue = await dbContext.Set<TEntity>().ToListAsync(cancellationToken);

            if (retValue == null)
            {
                throw new Exception($"Failed to find rows in {className} Table.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Failed to Get {className} Entities from database.");
            throw;
        }

        return retValue;
    }

    /// <summary>
    /// Gets a List of Data Models.
    /// </summary>
    /// <param name="pageIndex">int of Page Index.</param>
    /// <param name="pageSize">Page Size.</param>
    /// <param name="orderByColumn">column to order by.</param>
    /// <param name="cancellationToken">cancellationToken.</param>
    /// <returns>A list of TEntites.</returns>
    public virtual async Task<List<TEntity>> GetAllPageAsync(int pageIndex,
        int pageSize,
        bool includeDeleted,
        string orderByColumn = "Id",
        CancellationToken cancellationToken = default)
    {
        pageIndex = pageIndex - 1;
        try
        {
            return await dbContext.Set<TEntity>()
               .OrderBy(o => EF.Property<object>(o, orderByColumn))
               .Skip(pageIndex * pageSize)
               .Take(pageSize).ToListAsync(cancellationToken);

        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Failed to Get {className} Entities from database.");
            throw;
        }
    }

    /// <summary>
    /// Search by column.
    /// </summary>
    /// <param name="pageIndex">int of Page Index.</param>
    /// <param name="pageSize">Page Size.</param>
    /// <param name="orderByColumn">column to order by.</param>
    /// <param name="keyColumn">Column to use in search.</param>
    /// <param name="searchText">Text to search.</param>
    /// <param name="cancellationToken">cancellationToken.</param>
    /// <returns>A list of TEntites.</returns>
    public virtual async Task<IEnumerable<TEntity>> GetSearchEntityAsync(int pageIndex, int pageSize, string orderByColumn, string keyColumn, string searchText, CancellationToken cancellationToken = default)
    {
        List<TEntity> retValue;
        pageIndex = pageIndex - 1;
        try
        {
            retValue = await dbContext.Set<TEntity>()
            .Where(w => EF.Functions.Like((string)EF.Property<object>(w, keyColumn), $"%{searchText}%"))
            .OrderBy(o => EF.Property<object>(o, orderByColumn))
            .Skip(pageIndex * pageSize)
            .Take(pageSize).ToListAsync(cancellationToken);

        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Failed to Get Repository Entities from database.");
            throw;
        }

        return retValue;
    }
}
