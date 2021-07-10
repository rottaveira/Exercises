using System;

namespace Exercises
{ 
    public class QuadraticEquation
    {
        public static Tuple<double, double> FindRoots(double a, double b, double c)
        {
            var delta = Math.Sqrt(Math.Pow(b, 2) - (4 * a * c));
            var div = (2 * a);
            var x1 = (-b + delta) / div;
            var x2 = (-b - delta) / div;

            return new Tuple<double, double>(x1, x2);
        }

        public static void Run()
        {
            Tuple<double, double> roots = QuadraticEquation.FindRoots(2, 10, 8);
            Console.WriteLine("Roots: " + roots.Item1 + ", " + roots.Item2);
        }
    }
}
