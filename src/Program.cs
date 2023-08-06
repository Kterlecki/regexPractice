using System.ComponentModel;
using regexPractice.Services;
using regexPractice.Validator;

var fileContent = File.ReadAllText("test.cs");

// Services
var formattingServices = new FormattingService(fileContent);
var bracingServices = new BracingService(fileContent);
var indentationServices = new IndentationService(fileContent);
var userInputValidator = new UserInputValidator();

Console.WriteLine("***** File formatter *****");
Console.WriteLine("**************************");
Console.WriteLine();
Console.WriteLine("Please enter the following parameters:");

Console.Write("Indentation level required: ");
var indententationInput = Console.ReadLine();

if (!int.TryParse(indententationInput, out var indentation ))
{
    Console.WriteLine("Invalid indentation level. Please provide an integer value for indentation.");
    indentation = Int32.Parse(Console.ReadLine() ?? "0");
}
formattingServices.AddIndentation(indentation);

Console.WriteLine("Brace level required");
Console.WriteLine("For Same Line Enter - 1 ");
Console.WriteLine("For Own Line Enter - 2 ");
Console.Write("Enter brace level:");
var braceLineInput = Console.ReadLine();
if(!int.TryParse(braceLineInput, out var braceLine))
{
    Console.WriteLine("Invalid brace line selection. Please enter '1' for same line or '2' for own line.");
    return;
}

try
{
    if(userInputValidator.ValidateBraceUserInput(braceLine))
    {
        if (braceLine == 1)
    {
        formattingServices.BracesSameLine();
    }
        else if (braceLine == 2)
        {
            formattingServices.BracesOwnLine();
        }
        else
        {
            throw new Exception("Incorrect entry, Please try again");
        }
            };
}
catch (System.Exception ex)
{
    throw new Exception("Invalid entry for Brace input" + ex.Message);
}

Console.Write("Parameter spacing required: ");
var parameterSpacing = Console.ReadLine();
if (string.Equals(parameterSpacing, "yes", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Yes Selected");
    formattingServices.AddSpacing();
}
else if (string.Equals(parameterSpacing, "no", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("No Selected");
    formattingServices.RemoveSpacing();
}
else
{
    throw new Exception("\"Incorrect entry for Parameter Spacing, Please try again\"");
}


var finalFile = formattingServices.GetFile();
Console.WriteLine(finalFile);

using(var streamWriter = new StreamWriter("../FormattedOutputFile.cs")){
    streamWriter.Write(finalFile);
}

