using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingPython
{
    class Program
    {
        static void Main(string[] args)
        {

            var start = new ProcessStartInfo
            {
                FileName = @"cmd.exe",
                Arguments = "/c py --version",
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            // Specify exe name.

            using (var process = Process.Start(start))
            {
                //using (var reader = process.StandardError)
                //{
                //    var result = reader.ReadToEnd();
                //    return result;
                //    //MessageBox.Show(result);
                //}

                if (process == null) return;
                process.WaitForExit();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
            }
        }
    }
}
