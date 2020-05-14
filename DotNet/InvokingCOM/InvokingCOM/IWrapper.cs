using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvokingCOM
{
    public interface IWrapper
    {
        string ComponentId { get; }

        void Setup();

        void Configure();

        void Run();

        string SuccessMessage { get; }

        string ErrorMessage { get; }

        string LastTimeRun { get; }

        string AverageDuration { get; }

        IList<string> GetStepList();

        IList<string> GetWarningList();

        string Module { set; }

        bool DoneToday { get; }

        string LastStatus { get; }

        string ServerName { set; }

        string UserName { set; }

        string Password { set; }

        int UseSqlAuthentication { set; }

        string SqlDatabaseName { set; }
    }
}
