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

    public void Delete(int id)
    {
        T entryToDelete = _dbSet.Find(id);
        if(entryToDelete != null)
        {
            _dbSet.Remove(entryToDelete);
            _context.SaveChanges();
        } 

    }
    public List<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }
    public void Update(T updateEntry)
    {
        _dbSet.Update(updateEntry);
        _context.SaveChanges();
    }
    public void Save()
    {
        _context.SaveChanges();
    }
}

public interface IExerciseRepository<T>
{
    void Add(T entity);
    void Delete(int id);
    List<T> GetAll();
    void Update(T entity);
    T? GetById(int id);
    void Save();

}
