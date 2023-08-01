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
// Console.WriteLine("File name to be formatted:");
// var fileName = Console.ReadLine();
Console.Write("Indentation level required: ");
var indententation = Int32.Parse(Console.ReadLine());
Console.WriteLine("Brace level required");
Console.WriteLine("For Same Line Enter - 1 ");
Console.WriteLine("For Own Line Enter - 2 ");
Console.Write("Enter brace level:");
var braceLine = Console.ReadLine().ToLower();
Console.Write("Parameter spacing required: ");
var parameterSpacing = Console.ReadLine();
try
{
    if(userInputValidator.ValidateBraceUserInput(braceLine));
}
catch (System.Exception)
{
    throw new Exception("Invalid entry for Brace input");
}

if (braceLine == "1")
{
    formattingServices.BracesSameLine();
}
else if (braceLine == "2")
{
    formattingServices.BracesOwnLine();
}
else
{
    throw new Exception("Incorrect entry, Please try again");
}

if (parameterSpacing.ToLower() == "yes")
{
    formattingServices.AddSpacing();
}
else if (parameterSpacing.ToLower() == "no")
{
    Console.WriteLine("No Selected");
    formattingServices.RemoveSpacing();
}
else
{
    throw new Exception("\"Incorrect entry, Please try again\"");
}


formattingServices.AddIndentation(indententation);

Console.WriteLine(formattingServices.GetFile());

var finalFile = formattingServices.GetFile();

var outputFile = File.Create("abc.cs");
