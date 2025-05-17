using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly SportDbContext _context;
    protected readonly DbSet<T> _set;

    public BaseRepository(SportDbContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        IQueryable<T> query = _set;
        if (typeof(T) == typeof(Inventory))
        {
            query = query.Include("User");
        }
        return await query.ToListAsync();
    }

    public virtual async Task AddAsync(T entity)
    {
        await _set.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _set.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _set.Remove(entity);
        await _context.SaveChangesAsync();
    }
}