
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

    internal void DeleteExerciseEntry()
    {
        List<ExerciseItem> listOfEntries = _exerciseRepository.GetAll();
        int[] listOfIds = listOfEntries.Select(entry => entry.Id).ToArray();

        var grid = new Grid();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddRow(new Text[] {
            new Text("Id"),
            new Text("Date Start"),
            new Text("Date End"),
            new Text("Duration"),
            new Text("Comments"),
        });

        foreach (ExerciseItem entry in listOfEntries)
        {
            grid.AddRow(new Text[] {
                new Text(entry.Id.ToString()),
                new Text(entry.DateStart.ToString()),
                new Text(entry.DateEnd.ToString()),
                new Text(entry.Duration),
                new Text(entry.Comments)
            });
        }

        AnsiConsole.Write(grid);
        int IdToDelete = _userInput.GetInputId(listOfIds);
        _exerciseRepository.Delete(IdToDelete);        
        AnsiConsole.Write("\n[green]Successfully deleted \n\n");
        MainMenu.StartMenu();
    }

    internal void UpdateExerciseEntry()
    {
        List<ExerciseItem> listOfEntries = _exerciseRepository.GetAll();
        int[] listOfIds = listOfEntries.Select(entry => entry.Id).ToArray();

        var grid = new Grid();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddRow(new Text[] {
            new Text("Id"),
            new Text("Date Start"),
            new Text("Date End"),
            new Text("Duration"),
            new Text("Comments"),
        });

        foreach (ExerciseItem entry in listOfEntries)
        {
            grid.AddRow(new Text[] {
                new Text(entry.Id.ToString()),
                new Text(entry.DateStart.ToString()),
                new Text(entry.DateEnd.ToString()),
                new Text(entry.Duration),
                new Text(entry.Comments)
            });
        }

        AnsiConsole.Write(grid);
        int IdToUpdate = _userInput.GetInputId(listOfIds);
        ExerciseItem? exerciseEntry = _exerciseRepository.GetById(IdToUpdate);
        if (exerciseEntry == null) MainMenu.StartMenu();

        AnsiConsole.Write("Please write the id you want to update: \n");
        var (DateStart, DateEnd, Duration, Comments) = _userInput.GetInputExercise();
        
        exerciseEntry.DateStart = DateStart;
        exerciseEntry.DateEnd = DateEnd;
        exerciseEntry.Duration = Duration.ToString();
        exerciseEntry.Comments = Comments;

        _exerciseRepository.Update(exerciseEntry);

        AnsiConsole.Write("\n[green]Successfully edited \n\n");
        MainMenu.StartMenu();
    }

    internal void ViewAllExercisesEntries()
    {
        AnsiConsole.Markup("List of all exercises entries\n");
        List<ExerciseItem> listOfEntries = _exerciseRepository.GetAll();

        var grid = new Grid();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddRow(new Text[] {
            new Text("Id"),
            new Text("Date Start"),
            new Text("Date End"),
            new Text("Duration"),
            new Text("Comments"),
        });

        foreach (ExerciseItem entry in listOfEntries)
        {
            grid.AddRow(new Text[] {
                new Text(entry.Id.ToString()),
                new Text(entry.DateStart.ToString()),
                new Text(entry.DateEnd.ToString()),
                new Text(entry.Duration),
                new Text(entry.Comments)
            });
        }

        AnsiConsole.Write(grid);
        AnsiConsole.Write("\n");

        MainMenu.StartMenu();
    }
}
