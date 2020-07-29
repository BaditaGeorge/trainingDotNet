using System;

namespace boxing
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Teacher
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            object t = new Student();
            Teacher teacher = (Teacher)t;
            teacher.Name = "Mihai";
            teacher.Age = 32;
            Console.WriteLine(teacher.Name + " ; " + teacher.Age.ToString());
        }
    }
}
