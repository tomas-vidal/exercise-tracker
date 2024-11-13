
using Exercise;
using Spectre.Console;

public class ExerciseService
{
    private readonly IExerciseRepository<ExerciseItem> _exerciseRepository;
    private readonly UserInput _userInput;
    public ExerciseService(IExerciseRepository<ExerciseItem> exerciseRepository, UserInput userInput)
    {
        _exerciseRepository = exerciseRepository;
        _userInput = userInput;
    }

    public void AddExerciseEntry()
    {
        AnsiConsole.Markup("Add new exercise\n");
        var (DateStart, DateEnd, Duration, Comments) = _userInput.GetInputExercise();

        ExerciseItem newExerciseEntry = new ExerciseItem { DateStart = DateStart, DateEnd = DateEnd, Duration = Duration.ToString(), Comments = Comments};

        _exerciseRepository.Add(newExerciseEntry);
    }
}
