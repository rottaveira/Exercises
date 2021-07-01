using System;
using System.Collections.Concurrent; 
using System.Linq; 
using System.Threading.Tasks;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Question 1*/
            Friend a = new Friend("A");
            Friend b = new Friend("B");
            Friend c = new Friend("C");
            Friend d = new Friend("D");
            Friend e = new Friend("E");
            Friend f = new Friend("F");
            Friend g = new Friend("G");

            a.AddFriendship(b);
            b.AddFriendship(c);
            c.AddFriendship(d);
            d.AddFriendship(e);
            e.AddFriendship(f);

            var teste = f.CanBeConnected(a);
            Console.WriteLine(a.CanBeConnected(c));


            /*Question 2*/
            Func<int> expensiveFunction = () => Enumerable.Range(0, 200000000).Count();
            Func<int> cheapFunction = () => Enumerable.Range(0, 10000000).Count();
            Action<int> onSumChanged = sum => Console.WriteLine("Current result: " + sum);

            // Computationally expensive functions need more time than cheaper functions.
            // Because of this, computationally cheaper functions, when run in parallel, 
            // should be summed up before more expensive functions.
            // Expected output:
            // Current result: 10000000
            // Current result: 210000000
            // Final result: 210000000
            int result = Sum(new Func<int>[] { expensiveFunction, cheapFunction }, onSumChanged);
            Console.WriteLine("Final result: " + result);
        }


        public static int Sum(Func<int>[] functions, Action<int> onSumChanged)
        {

            var listCredito = new ConcurrentStack<int>();
            var pareallel = Parallel.ForEach(functions, new ParallelOptions { }, (function, loopState) =>
            {
                listCredito.Push(function());
                onSumChanged(listCredito.Sum());
            });

            return listCredito.Sum();
        }
    } 

}
