using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace regexPractice.Services
{
    public class IndentationService
    {
        public readonly string _file;
        public IndentationService(string file)
        {
            _file = file;
        }

        public string AddIndentation(int indent)
        {
            var emptySpace = " ";
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < indent; i++)
            {
                stringBuilder.Append(emptySpace);
            }
            var result = stringBuilder.Append("result").ToString();

            var updatedIndentation = _file.Replace("return", result);
            return updatedIndentation;
        }
    }
}
