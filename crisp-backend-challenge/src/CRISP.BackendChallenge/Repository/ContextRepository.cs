using CRISP.BackendChallenge.Context;
using CRISP.BackendChallenge.Context.Models;

namespace CRISP.BackendChallenge.Repository;

public class ContextRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;

    public ContextRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> Query()
    {
        return _context.Set<T>().AsQueryable();
    }

    /// <inheritdoc />
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    /// <inheritdoc />
    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    /// <inheritdoc />
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    /// <inheritdoc />
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    /// <inheritdoc />
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    /// <inheritdoc />
    public void Save()
    {
        _context.SaveChanges();
    }
}