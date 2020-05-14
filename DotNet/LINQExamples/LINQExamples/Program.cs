using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace LINQExamples
{
    class Program
    {
        public static void Main(string args)
        {
            new Student().Logit();

            Console.ReadLine();
        }

        

        static void Main1(string[] args)
        {
            Student s = new Student {Id = 1, Name = "Eze", City = "Hyd"};
            Student s1 = new Student { Id = 2, Name = "SS&C", City = "Boston" };
            Student s2 = new Student { Id = 3, Name = "Eze Castle", City = "Chicago" };
            Student s3 = new Student { Id = 4, Name = "Eze Castle", City = "London" };

            List<Student> students = new List<Student>();
            students.Add(s);
            students.Add(s1);

            List<Student> studentsOneMoreTime = new List<Student>();
            studentsOneMoreTime.Add(s2);
            studentsOneMoreTime.Add(s3);

            students.AddRange(studentsOneMoreTime);



            var result = students.Where(x => x.Name == "Eze Castle")
                .Select(a => new
            {
                Id = a.Id,
                Name = a.Name
            });


           foreach (var first in result)
           {
               Console.WriteLine(first.Id +" - " +first.Name);   
           }

            Console.ReadLine();

        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public void Logit()
        {
          //  Log(this, " sent p");
            Log(GetType(), " type");
        }

        void Log(Type type, string message)
        {
            Console.WriteLine(type + message);
        }
    }
}
