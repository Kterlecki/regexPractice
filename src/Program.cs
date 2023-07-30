using System.ComponentModel;
using regexPractice.Services;

var fileContent = File.ReadAllText("test.cs");

//var count = 0;
//for(int i = 0; i < fileContent.Length; i++)
//{
//    if (fileContent[i] == '\n')
//    {
//        count ++;
//    }
//}
//Console.WriteLine(count);


// Services
var formattingServices = new FormattingService(fileContent);
var bracingServices = new BracingService(fileContent);
var indentationServices = new IndentationService(fileContent);



Console.WriteLine("***** File formatter *****");
Console.WriteLine("**************************");
Console.WriteLine();
Console.WriteLine("Please enter the following parameters:");
// Console.WriteLine("File name to be formatted:");
// var fileName = Console.ReadLine();
// Console.Write("Indentation level required: ");

// var indententation = Int32.Parse(Console.ReadLine());
// Console.Write("Brace level required - Same Line or Own Line: ");
// var braceLine = Console.ReadLine();
Console.Write("Parameter spacing required: ");
var parameterSpacing = Console.ReadLine();

// if (braceLine.ToLower() == "same line")
// {
//     formattingServices.BracesSameLine();
// }
// else if (braceLine.ToLower() == "own line")
// {
//     formattingServices.BracesOwnLine();
// }
// else
// {
//     throw new Exception("\"Incorrect entry, Please try again\"");
// }

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


// formattingServices.AddIndentation(indententation);

Console.WriteLine(formattingServices.GetFile());

var finalFile = formattingServices.GetFile();

var outputFile = File.Create("abc.cs");
