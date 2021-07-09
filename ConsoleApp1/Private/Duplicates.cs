using System;
using System.Diagnostics;
using System.Text; 

namespace Exercises
{
    public class Duplicates
    { 
        public static void Run()
        {
            /*Question 3*/
            var text = "aabbccddbb";
            Console.WriteLine("Final result: " + removeDuplicates(text));
        }

        public static String removeDuplicates(String str)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            /*Opcao 1 - best approach*/
            bool[] seen = new bool[256];
            StringBuilder sb = new StringBuilder(seen.Length);

            
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                seen = i > 0 ? str[i] == str[i - 1] ? seen : new bool[256] : seen;

                if (!seen[ch])
                {
                    seen[ch] = true;
                    sb.Append(ch);
                }
            } 
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);


            sw.Start();
            /*Opcao 2*/
            var a = "";
            for (int i = 0; i < str.Length; i++)
            {
                a += i > 0 ? str[i] == str[i - 1] ? string.Empty : str[i].ToString() : str[i].ToString();
            }
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);


            sw.Start();
            /*Opcao 3*/
            StringBuilder sbb = new StringBuilder(256);
            int j = 0;
            while(j < str.Length)
            {
                sbb.Append( j > 0 ? str[j] == str[j - 1] ? "" : str[j].ToString() : str[j].ToString());
                j++;
            }
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);

            return sb.ToString(); 
        }
    }
}
