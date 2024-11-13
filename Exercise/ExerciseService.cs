
using Exercise;

public class ExerciseService
{
    private readonly IExerciseRepository<ExerciseItem> _exerciseRepository;
    public ExerciseService(IExerciseRepository<ExerciseItem> exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }
}
