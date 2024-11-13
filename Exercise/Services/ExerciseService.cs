
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
        AnsiConsole.Markup("Add new exercise");
        string nameExercise = _userInput.InputExerciseName();
        DateTime dateStart = _userInput.InputDateStart();
        DateTime dateEnd = _userInput.InputDateEnd();
        TimeSpan duration = _userInput.InputDuration();
        string comments = _userInput.InputComment();
    }
}
