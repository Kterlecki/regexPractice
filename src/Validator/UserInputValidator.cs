namespace regexPractice.Validator;

public class UserInputValidator
{
    public bool ValidateBraceUserInput(string userInput)
    {
        return userInput is "1" or "2";
    }
}