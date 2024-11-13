using Spectre.Console;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserInput
{
    internal (DateTime dateStart, DateTime dateEnd, TimeSpan duration, string comments) GetInputExercise()
    {
        DateTime dateStart = InputDateStart();
        DateTime dateEnd = InputDateEnd();
        TimeSpan duration = InputDuration();
        string comments = InputComment();

        return (dateStart, dateEnd, duration, comments);
    }
    internal DateTime InputDateStart()
    {
        var stringInput = "";
        DateTime dateParsed;
        stringInput = AnsiConsole.Prompt(new TextPrompt<string>("When did you start? (dd-MM-yyyy): "));
        while (stringInput == "" || !DateTime.TryParseExact(stringInput, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParsed))
        {
            stringInput = AnsiConsole.Prompt(new TextPrompt<string>("Invalid input, please try again: "));
        }
        return dateParsed;
    }
    internal DateTime InputDateEnd()
    {
        var stringInput = "";
        DateTime dateParsed;
        stringInput = AnsiConsole.Prompt(new TextPrompt<string>("When did you end? (dd-MM-yyyy): "));
        while (!DateTime.TryParseExact(stringInput, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParsed))
        {
            stringInput = AnsiConsole.Prompt(new TextPrompt<string>("Invalid input, please try again: "));
        }
        return dateParsed;
    }

    internal TimeSpan InputDuration()
    {
        var stringInput = "";
        TimeSpan timeParsed;
        stringInput = AnsiConsole.Prompt(new TextPrompt<string>("For how long did you exercise (HH:mm): "));
        while (!TimeSpan.TryParseExact(stringInput, "h\\:mm", CultureInfo.InvariantCulture, TimeSpanStyles.AssumeNegative, out timeParsed))
        {
            stringInput = AnsiConsole.Prompt(new TextPrompt<string>("Invalid input, please try again: "));
        }
        return timeParsed;
    }
    internal string InputComment()
    {
        var stringInput = "";
        stringInput = AnsiConsole.Prompt(new TextPrompt<string>("Write a comment if you want: "));
        return stringInput;
    }
}
