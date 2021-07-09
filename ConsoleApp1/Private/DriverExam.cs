using System;

namespace Exercises
{
    public class Driver
    {
        public static void Run()
        {
            DriverExam.ExecuteExercise(new Exercise());
        }
    }

    public class DriverExam
    {
        public static void ExecuteExercise(IExercise exercise)
        {
            try
            {
                exercise.Start();
                exercise.Execute();
            }
            catch
            {
                exercise.MarkNegativePoints();
                exercise.End();
            }
            exercise.End();
        }
    }

    public interface IExercise
    {
        void Start();
        void Execute();
        void MarkNegativePoints();
        void End();
    }

    public class Exercise : IExercise
    {
        public void Start() { Console.WriteLine("Start"); }
        public void Execute() { Console.WriteLine("Execute"); }
        public void MarkNegativePoints() { Console.WriteLine("MarkNegativePoints"); }
        public void End() { Console.WriteLine("End"); }
    }




}
