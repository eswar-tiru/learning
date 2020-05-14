using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReferenceInConstructor
{
    public class Program
    {
        static void Main1(string[] args)
        {
            var nn = new Name {First = "FirstNn", Last = "LastNn"};
            var ff = "FirstNameff";
            var ll = "LastNamell";

            var P = new Person(ff,ll,nn);

            P.FirstName = "P";
            P.LastName = "L";
            P.NameObject.First = "PNF";
            P.NameObject.Last = "PNL";

            //Console.WriteLine(nn.First);
            //Console.WriteLine(nn.Last);
            //Console.WriteLine(ff);
            //Console.WriteLine(ll);

            nn.First = "Eswar";
            Console.WriteLine(P.NameObject.First);

            var pc = P.GetNewObject(P.FirstName, P.LastName, P.NameObject);

            pc.FirstName = "PCF";
            pc.LastName = "PCL";
            pc.NameObject.First = "PCNF";
            pc.NameObject.Last = "PCNL";

            Console.WriteLine($"{P.FirstName} -> {P.LastName} -> {P.NameObject.First} -> {P.NameObject.Last}");
            Console.WriteLine($"{pc.FirstName} -> {pc.LastName} -> {pc.NameObject.First} -> {pc.NameObject.Last}");

            Console.ReadLine();
        }
    }


    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Name NameObject { get; set; }

        public Person(string f, string l, Name n)
        {
            FirstName = f;
            LastName = l;
            NameObject = n;
        }

        public Person GetNewObject(string f, string l, Name n)
        {
            var n1 = new Name {First = n.First, Last = n.Last};
            return new Person(f, l, n1);
        }
    }

    public class Name
    {
        public string First { get; set; }
        public string Last { get; set; }
    }
}
