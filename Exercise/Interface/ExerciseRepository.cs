using Exercise;
using Microsoft.EntityFrameworkCore;

public class ExerciseRepository<T> : IExerciseRepository<T> where T : class
{
    private readonly ExerciseContext _context;
    private readonly DbSet<T> _dbSet;

    public ExerciseRepository(ExerciseContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
    public List<T> GetAll()
    {
        return _dbSet.ToList();
    }
    public void Save()
    {
        _context.SaveChanges();
    }
}

public interface IExerciseRepository<T>
{
    void Add(T entity);
    void Delete(T entity);
    List<T> GetAll();
    void Save();

}
