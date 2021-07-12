using System;
using System.Collections.Generic;
using System.Linq; 

namespace Exercises
{
    class TwoSum
    {
        public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
        {
            var conjuntosValidos = Enumerable.Range(0, 1 << (list.Count)).Select(index => list.Where((v, i) => (index & (1 << i)) != 0)).Where(w => w.Count() == 2 && w.Sum() == sum).ToArray();
            var first = conjuntosValidos.FirstOrDefault();

            if (first == null) return null;

            return new Tuple<int, int>(list.IndexOf(first.First()), list.IndexOf(first.Last()));
        }


        public static void Run()
        { 
            Tuple<int, int> indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
            if (indices != null)
            {
                Console.WriteLine(indices.Item1 + " " + indices.Item2);
            }
        }
    }
}
