using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
           Regex regex = new Regex(@"\(\s*(\w+)\s*\)");
            string formattedContent = Regex.Replace(_file, @"\(\s*(\w+)\s(\w+)\s*\)", "($1 $2)");
            _file = formattedContent;
            File.WriteAllText("test.cs", formattedContent);
        }

        public void AddIndentation(int indent)
        {
            var emptySpace = " ";
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < indent; i++)
            {
                stringBuilder.Append(emptySpace);
            }
            var result = stringBuilder.Append("result").ToString();

            var updatedIndentation = _file.Replace("return", result);
            _file = updatedIndentation;
        }

        public void BracesSameLine()
        {
            //var emptySpace = " ";
            //var stringBuilder = new StringBuilder();
            //var found = false;
            //while (found == false)
            //{
            //    for (int i = 0; i < _file.Length; i++)
            //    {
            //        if (_file[i] == ')')
            //        {
            //            stringBuilder.Append(emptySpace);
            //        }

            //    }
            //    stringBuilder.Append(emptySpace);
            //}
            //var result = stringBuilder.Append("result").ToString();
            var updateBracesToSameLine = _file.Replace(" \r\n            {", "{");
            _file = updateBracesToSameLine;
        }

        public void BracesOwnLine()
        {
            var updateBracesToSameLine = _file.Replace(" \r\n            {", "{");
            _file = updateBracesToSameLine;
        }
    }
}