﻿
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

        var deleteEntry = AnsiConsole.Prompt(
            new SelectionPrompt<ExerciseItem>()
            .Title("Select the exercise you want to delete: ")
            .AddChoices(listOfEntries));

        _exerciseRepository.Delete(deleteEntry);

        AnsiConsole.Markup("[green]Successfully deleted \n");
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
        grid.AddRow(new Text[] {
            new Text("Date Start"),
            new Text("Date End"),
            new Text("Duration"),
            new Text("Comments")
        });

        foreach (ExerciseItem entry in listOfEntries)
        {
            grid.AddRow(new Text[] { 
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
