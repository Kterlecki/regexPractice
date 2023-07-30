using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxFormatter.Services
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
            var updateRightBracketSpace= _file.Replace(")", " )");
            var updateLeftBracketSpace = updateRightBracketSpace.Replace("(", "( ");
            _file = updateLeftBracketSpace;
        }
        public void RemoveSpacing()
        {
            var updateRightBracketSpace = _file.Replace(" )", ")");
            var updateLeftBracketSpace = updateRightBracketSpace.Replace("( ", "(");
            _file = updateLeftBracketSpace;
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