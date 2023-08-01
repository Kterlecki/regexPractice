using System.Text.RegularExpressions;
using System.Text;

namespace regexPractice.Services
{
    public class FormattingService
    {
        private string _file;

        public FormattingService(string file)
        {
            _file = file;
        }
        public string GetFile()
        {
            return _file;
        }
        public void AddSpacing()
        {
            Regex regex = new Regex(@"\(([^)]*)\)");
            string formattedContent = regex.Replace(_file, "( $1 )");
            _file = formattedContent;
            File.WriteAllText("test.cs", formattedContent);
        }
        public void RemoveSpacing()
        {
            string formattedContent = Regex.Replace(_file, @"\(\s*(\w+)\s(\w+)\s*\)", "($1 $2)");
            _file = formattedContent;
            File.WriteAllText("test.cs", formattedContent);
        }

        public void AddIndentation(int indent)
        {
            const string emptySpace = " ";
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < indent; i++)
            {
                stringBuilder.Append(emptySpace);
            }
            var result = stringBuilder.Append("return").ToString();

            var updatedIndentation = _file.Replace("return", result);
            _file = updatedIndentation;
        }

        public void BracesSameLine()
        {
            var updateBracesToSameLine = Regex.Replace(_file, @"\s*\{\s*(\w+)\s(\w+);\s*\}", "{$1 $2}");
            _file = updateBracesToSameLine;
        }

        public void BracesOwnLine()
        {
            var updateBracesToSameLine = Regex.Replace(_file, @"\{(\w+)\s(\w+)\}", @"/n{$1 $2 /n}");
            _file = updateBracesToSameLine;
        }
    }
}