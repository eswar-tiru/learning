using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InvokingCOMFromService
{
    public class Wrapper : IWrapper, IDisposable
    {
        private readonly dynamic _interopt;
		private const string MessageInitError = @"Initialize component {0} error. Please check if COM service has been registered.";


        public Wrapper()
		{
			try
			{
                _interopt = Activator.CreateInstance(Type.GetTypeFromProgID("EzeClientDataExport.DataExport"));

                ServerName = "CHEEMAKURTHY749";
				UserName = "sa";
				Password = "ezetc123";
				UseSqlAuthentication = 0;
				SqlDatabaseName = "TC";
                Module = "NeutronProc1";
				ComponentId = "EzeClientDataExport.DataExport";
			}
			catch (Exception e)
			{
				throw new COMException(
					string.Format(MessageInitError, e.Message),
					e.InnerException);
			}
		}
        
		#region IWrapper interface

		public string ComponentId { get; set; }

		public string LastStatus
		{
			get { return _interopt == null ? string.Empty : _interopt.LastStatus; }
		}

		public string LastTimeRun
		{
			get { return _interopt == null ? string.Empty : _interopt.LastTimeRun; }
		}

		public string AverageDuration
		{
			get { return _interopt == null ? string.Empty : _interopt.AverageDuration; }
		}

		public bool DoneToday
		{
			get { return _interopt == null ? string.Empty : _interopt.DoneToday; }
		}

		public IList<string> GetStepList()
		{
			IList<string> list = new List<string>();
			if (_interopt == null)
			{
				return list;
			}

			for (int i = 0; i < _interopt.StepList.Count(); i++)
			{
				list.Add((string)_interopt.StepList[i]);
			}

			return list;
		}

		public IList<string> GetWarningList()
		{
			IList<string> list = new List<string>();
			if (_interopt == null)
			{
				return list;
			}

			for (int i = 0; i < _interopt.WarningList.Count(); i++)
			{
				list.Add((string)_interopt.WarningList[i]);
			}

			return list;
		}

		public string ErrorMessage
		{
			get { return _interopt == null ? string.Empty : _interopt.ErrorMessage; }
		}

		public string SuccessMessage
		{
			get { return _interopt == null ? string.Empty : _interopt.SuccessMessage; }
		}

		public string Module
		{
			set { _interopt.Module = value; }
		}

		public string ServerName
		{
			set { _interopt.ServerName = value; }
		}

		public string UserName
		{
			set { _interopt.UserName = value; }
		}

		public string Password
		{
			set { _interopt.Password = value; }
		}

		public int UseSqlAuthentication
		{
			set { _interopt.UseSqlAuthentication = value; }
		}

		public string SqlDatabaseName
		{
			set { _interopt.SqlDatabaseName = value; }
		}

		public void Setup()
		{
			_interopt.Setup();
		}

		public void Configure()
		{
			_interopt.Configure();
		}

		public void Run()
		{
			_interopt.Run();
		}
		#endregion


        public void Dispose()
        {
			try
			{
				_interopt.DisposeCom();
			}
			catch(Exception ex)
			{

			}
        }
    }
}
