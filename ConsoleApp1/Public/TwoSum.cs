using System;
using System.Collections.Generic;
using System.Linq; 

namespace Exercises
{
    class TwoSum
    {
        public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
        {

            /*Solução top, mas só passa 50%*/
            /*var conjuntosValidos = Enumerable.Range(0, 1 << (list.Count)).Select(index => list.Where((v, i) => (index & (1 << i)) != 0)).Where(w => w.Count() == 2 && w.Sum() == sum).ToArray();
             *  var first = conjuntosValidos.FirstOrDefault();
             *
             *  if (first == null) return null;
             *
             *  return new Tuple<int, int>(list.IndexOf(first.First()), list.IndexOf(first.Last()));
             */


            /*Segunda tentativa, passa só 50% tbm*/
            /*for (int i = 0; i < list.Count; i++)
             *  { 
             *      var res = list.FirstOrDefault((a) => a + list[i] == sum);
             *
             *      if (res > 0)
             *          return new Tuple<int, int>(list.IndexOf(res), list.IndexOf(list[i]));
             *  }
             *  return null;
             */

            /*terceira tentativa - passa só 50% tbm*/
            /*  var count = list.Count;
             *  var lista = list.ToList();
             *  for (int i = 0; i < count; i++)
             *  {
             *
             *      var res = lista.GetRange(i, count - (i + 1)).FirstOrDefault((a) => a + list[i] == sum);
             *
             *      if (res > 0)
             *          return new Tuple<int, int>(list.IndexOf(res), list.IndexOf(list[i]));
             *  }
             *  return null;
             */


            /*terceira tentativa - passa só 50% tbm */
            var teste = new List<Tuple<int, int>>();

            int c = 0;
            var dict = list.ToDictionary(v => c++, k => k);
            for (int i = 0; i < list.Count; i++)
             {
                var valordesejado = sum - list[i];
                if (dict.ContainsValue(valordesejado))
                    return new Tuple<int, int>(i, dict.FirstOrDefault(f => f.Key != i && f.Value == valordesejado).Key); 
                    //teste.Add( new Tuple<int, int>(i, dict.FirstOrDefault(f => f.Key != i && f.Value == valordesejado).Key)); 
                    
             }

             return null;

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
