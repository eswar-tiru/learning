using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskArrayExample
{
    public class Middle
    {
        private Final _f;
        public Middle(Final f)
        {
            _f = f;
            //Task.Run(() => Console.Write("sadf"));
        }

        public async Task CallWD(string data)
        {
            Console.WriteLine("Hey");
            await _f.WriteData(data);
        }

        public async Task PerformAction(string data)
        {
            //var tasks1 = new[]
            //{
            CallWD(data + "1");
            CallWD(data + "1");
            CallWD(data + "1");
            CallWD(data + "1");
            CallWD(data + "1");
            //};


            //async 1,2,3
            //var t1= 1
            //var t2 =2
            //var t3 = 3


            //await t1
            //await t2
            //await t3

            var tasks = new[]
            {
                new Task(() => CallWD(data + "1")),
                new Task(() => CallWD(data + "1")),
                new Task(() => CallWD(data + "1")),
                new Task(() => CallWD(data + "1")),
                new Task(() => CallWD(data + "1"))
            };

            //foreach (var task in tasks)
            //{
            //    task.Start();
            //}

            var t = Task.WhenAll(tasks);
            await t;
        }

    }
}
