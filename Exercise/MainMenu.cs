using Controller;
using Exercise;
using Spectre.Console;

public class MainMenu
{

    public enum Choice
    {
        AddExerciseEntry,
        ViewAllExerciseEntry,
        UpdateExerciseEntry,
        DeleteExerciseEntry,
        Quit,
    }

    public static void StartMenu()
    {
       var exerciseContext = new ExerciseContext();
       var exerciseRepository = new ExerciseRepository<ExerciseItem>(exerciseContext);
       var userInput = new UserInput();
       var exerciseService = new ExerciseService(exerciseRepository, userInput);
       var exerciseController = new ExerciseController(exerciseService);

       var userChoice = AnsiConsole.Prompt(
            new SelectionPrompt<Choice>()
            .Title("Select your choice:")
            .AddChoices(new[]
            {
                Choice.AddExerciseEntry,
                Choice.ViewAllExerciseEntry,
                Choice.UpdateExerciseEntry,
                Choice.DeleteExerciseEntry,
                Choice.Quit,
            }));

        while (true)
        {
            switch(userChoice) 
            {
                case Choice.AddExerciseEntry:
                    exerciseController.AddExercise();
                    break;
                case Choice.ViewAllExerciseEntry:
                    exerciseController.ViewExercises();
                    break;
                case Choice.DeleteExerciseEntry:
                    exerciseController.DeleteExercise();
                    break;
                case Choice.UpdateExerciseEntry:
                    break;
                case Choice.Quit:
                    break;
            }
        }
    }
}
