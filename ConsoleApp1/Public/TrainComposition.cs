using System;
using System.Collections.Generic;

namespace Exercises
{
    public class TrainComposition
    {
        LinkedList<int> wagons = new LinkedList<int>();

        public void AttachWagonFromLeft(int wagonId)
        {
            wagons.AddFirst(wagonId);
        }

        public void AttachWagonFromRight(int wagonId)
        {
            wagons.AddLast(wagonId);
        }

        public int DetachWagonFromLeft()
        {
            var wagon = wagons.First;
            wagons.Remove(wagon);

            return wagon.Value;
        }

        public int DetachWagonFromRight()
        {
            var wagon = wagons.Last;
            wagons.Remove(wagon);

            return wagon.Value;
        }

        public static void Run()
        {
            TrainComposition train = new TrainComposition();
            train.AttachWagonFromLeft(7);
            train.AttachWagonFromLeft(13);
            Console.WriteLine(train.DetachWagonFromRight()); // 7 
            Console.WriteLine(train.DetachWagonFromLeft()); // 13
        }

    }
}
