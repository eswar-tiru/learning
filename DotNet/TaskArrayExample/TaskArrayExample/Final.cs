using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskArrayExample
{
    public class Final
    {
        public async Task WriteData(string data)
        {
            var datetime = DateTime.Now;
            await Task.Run(() =>
                File.AppendAllText("Eswar.txt", "Eswar" + datetime.Ticks+ ".txt - " + data));
        }
    }
}
