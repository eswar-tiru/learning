using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMAdmin;

namespace InvokingCOM
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = Environment.SystemDirectory;
            //Console.WriteLine(a);
            //var wrapper = new Wrapper();
            //wrapper.Setup();
            //wrapper.Run();

            COMAdminCatalog c = new COMAdminCatalog();
            var cl = (COMAdminCatalogCollection)c.GetCollection("Applications");
            cl.Populate();

            foreach (COMAdminCatalogObject obj in cl)
            {
                Console.WriteLine(obj.Name);
            }

            Console.ReadLine();
        }
    }
}
