using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            OperationsServiceRequest ops = new OperationsServiceRequest(Guid.NewGuid());
            OperationsServiceDataRequest ops1 = new OperationsServiceDataRequest(Guid.NewGuid()){ProcessId = Guid.NewGuid()};

            Console.WriteLine(ops.PrintParameters());
            Console.WriteLine(ops1.PrintParameters());
        }
    }


    public class OperationsServiceRequest
    {
        public Guid RequestId { set; get; }

        public OperationsServiceRequest(Guid requestId)
        {
            RequestId = requestId;
        }
    }

    public class OperationsServiceDataRequest : OperationsServiceRequest
    {
        public OperationsServiceDataRequest(Guid requestId)
            : base(requestId)
        {
        }

        public Guid ProcessId { get; set; }
    }
}
