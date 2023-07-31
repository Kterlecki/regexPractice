namespace regexPractice.Validator;

public class UserInputValidator
{
    public bool ValidateBraceUserInput(string userInput)
    {
        return userInput is "same line" or "own line";
    }
}