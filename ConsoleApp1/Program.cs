using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeNames.Run();
        }




        public void RunFriend()
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
        }

   
    } 

}
