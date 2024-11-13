using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserInput
{
    internal string InputComment()
    {
        throw new NotImplementedException();
    }

    internal DateTime InputDateEnd()
    {
        throw new NotImplementedException();
    }

    internal DateTime InputDateStart()
    {
        throw new NotImplementedException();
    }

    internal TimeSpan InputDuration()
    {
        throw new NotImplementedException();
    }

    internal string InputExerciseName()
    {
        var stringInput = "";
        stringInput = AnsiConsole.Prompt(new TextPrompt<string>("What's the name of the exercise?: "));
        while (stringInput == "")
        {
            stringInput = AnsiConsole.Prompt(new TextPrompt<string>("Invalid input, please try again: "));
        }
        return stringInput;
    }
}
