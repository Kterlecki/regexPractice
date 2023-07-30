using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxFormatter.Services
{
    public class BracingService
    {
        private readonly string _file;

        public BracingService(string file) 
        {
            _file = file;
        }
        public string BracesSameLine()
        {
            //var emptySpace = " ";
            //var stringBuilder = new StringBuilder();
            //var found = false;
            //while (found == false)
            //{
            //    for(int i = 0; i < _file.Length; i++)
            //    {
            //        if (_file[i] == '\n')
            //        {
            //            stringBuilder.Append(emptySpace);
            //        }

            //    }
            //    stringBuilder.Append(emptySpace);
            //}
            //var result = stringBuilder.Append("result").ToString();
            var updateBracesToSameLine = _file.Replace("\r\n{", "}");
            return updateBracesToSameLine;
        }

        public string BracesOwnLine()
        {
            var updateBracesToSameLine = _file.Replace(" {", "abc");
            return updateBracesToSameLine;
        }
    }
}
