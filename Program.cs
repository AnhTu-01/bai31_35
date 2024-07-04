using System;

namespace MyCSharpProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Person obs = new Student { Name = "Nguyễn Văn Nam", Major = "ICT" };

            if (obs is Student student)
            {
                student.kpi();
            }
            else
            {
                Console.WriteLine("obs is not a Student.");
            }
        }
    }
}