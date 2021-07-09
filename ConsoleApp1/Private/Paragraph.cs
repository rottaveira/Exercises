using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Exercises
{
    /* Replace all occurrences of XXX-YY-ZZZZ with XXX/YY/ZZZZ*/
    public class Paragraph
    {
        private const string Separator = @"/";
        private const string Expression = @"\D{3}-\D{2}-\D{4}";

        private static readonly Regex Regex = new Regex(Expression, RegexOptions.Compiled);

        public static string ChangeFormat(string paragraph)
        {
            return Regex.Replace(paragraph, match =>
           {
               var found = match.ToString();
               var parts = found.Split('-');
               return $@"{parts[0]}{Separator}{parts[1]}{Separator}{parts[2]}";
           });
        }

        public static void Run()
        {
            Stopwatch sw = new Stopwatch();
            var word = "fds-re-fare";

            sw.Start();
            var result1 = ChangeFormat(word);
            sw.Stop();

            Console.WriteLine("Final result: " + result1);
            Console.WriteLine("Elapsed={0}", sw.Elapsed);

            sw.Start();
            var result2 = word.Replace("-","/");
            sw.Stop();

            Console.WriteLine("Final result: " + result2);
            Console.WriteLine("Elapsed={0}", sw.Elapsed);

        }
    }
}
