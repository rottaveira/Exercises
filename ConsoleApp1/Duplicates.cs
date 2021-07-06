using System; 
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
            
            /*Opcao 1*/
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

            /*Opcao 2*/
            var a = "";
            for (int i = 0; i < str.Length; i++)
            {
                a += i > 0 ? str[i] == str[i - 1] ? string.Empty : str[i].ToString() : str[i].ToString();
            }
              
            return sb.ToString();
        }
    }
}
