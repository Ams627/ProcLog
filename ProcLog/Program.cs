using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcLog
{
    using System.Text.RegularExpressions;

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new Exception("You must supply a tcc log filename");
                }
                var filename = args[0];
                var dateBracketPattern = @"\[(\d{2}/\d{2}/\d{2}) (\d{2}:\d{2}:\d{2})\]";
                var logDict = new SortedDictionary<DateTime, SortedSet<int>>();
                foreach (var line in File.ReadLines(filename))
                {
                    var regexResult = Regex.Match(line, dateBracketPattern);
                    var dateGroup = regexResult.Groups[1];
                    var timeGroup = regexResult.Groups[2];
                    var time = timeGroup[0] - '0';
                }
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
