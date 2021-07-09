
using System;
using System.Collections.Generic;  

/*
Add property IEnumerable<string> Students to class Classroom that:
Has a public getter
Has a private setter
Returns students that are given through the constructor
*/

public class Classroom
{
    private IEnumerable<string> students;

    public IEnumerable<string> Students
    {
        get { return students; }
        private set { students = value; }
    }

    public Classroom(List<string> students)
    {
        Students = students;
    }

    public static void Run()
    {
        List<string> students = new List<string>() { "John", "Ana", "Carol" };
        Classroom classroom = new Classroom(students);

        foreach (string student in classroom.Students)
        {
            Console.WriteLine(student);
        }
    }
}