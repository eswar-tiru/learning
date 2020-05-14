using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace InvokingCOMFromService
{
    public partial class InvokingCOMFromService : ServiceBase
    {
        private Timer t;
        public InvokingCOMFromService()
        {
            InitializeComponent();
            t = new Timer(10000);
        }

        protected override void OnStart(string[] args)
        {
            t.Elapsed += t_Elapsed;
            //t.Enabled = true;
            t.Start();
        }

        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {

                t.Stop();

                var w = new Wrapper();
                w.Setup();
                w.Run();

                t.Start();

            }
            catch (Exception exception)
            {
                File.WriteAllText(@"D:\Eswar\Logfile"+DateTime.Now+".txt", exception.ToString());
                t.Stop();
            }
        }

        protected override void OnStop()
        {
            t.Stop();
        }
    }
}
