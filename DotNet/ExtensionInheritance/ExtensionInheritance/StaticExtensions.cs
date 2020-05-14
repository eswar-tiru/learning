using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionInheritance
{
    static class StaticExtensions
    {
        public static string PrintParameters(this OperationsServiceRequest ops)
        {
            string value = "Parameters";
            foreach (var property in ops.GetType().GetProperties())
            {
                value = string.Format("{0} , {1} - {2} ", value, property.Name, property.GetValue(ops));
            }
            return value;
        }

        public static string PrintParameters(this OperationsServiceDataRequest ops)
        {
            string value = "Parameters";
            foreach (var property in ops.GetType().GetProperties())
            {
                value = string.Format("{0} , {1} - {2} ", value, property.Name, property.GetValue(ops));
            }
            return value;
        }
    }
}
