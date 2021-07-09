using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Exercises
{ 
    /*Implement the function Count, which returns the number of lines from the Stream that contains text matching the string provided.
        For example, when the string needle is "there" and the Stream haystack contains:
        Hello, there!
        How are you today?
        Yes, you over there.
        The Count function should return 2 ("Hello, there!" and "Yes, you over there.").*/

    public class Needle
    {
        public static int Count(string needle, Stream haystack)
        {
            /*Option 1*/
            /*Dessa maneira, avalia a quantidade de palavras, não levando em conta a frase.*/
            StreamReader reader = new StreamReader(haystack);
            string s = reader.ReadToEnd();

            string[] src = s.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var results = from word in src
                          where word.Contains(needle)
                          select word;
             
            var teste = src.Count(c => c == needle);


            /*Option 2*/
            /*Avalia a frase inteira, mesmo q a palavra se repita, considera como 1 frase válida*/
            StreamReader reader2 = new StreamReader(haystack);
            string s2 = reader.ReadToEnd();

            var src2 = s.Split(new char[] {'\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var res = src2.Count(cc => cc.Contains(needle));

            return results.Count();
        }

        public static void Run()
        {
            string message = "Hello, there there!\nHow are you today?\nYes, you over there.";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(message)))
                Console.WriteLine(Needle.Count("there", stream));
        }
    }
}


