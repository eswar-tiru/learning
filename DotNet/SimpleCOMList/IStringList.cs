using System.Runtime.InteropServices;

namespace SimpleCOMList
{
    [Guid("8b12bc89-8056-482b-b2f1-e8f8cf8da407")]
    [ComVisible(true)]
    public interface IStringList
    {
        string this[int index]
        {
            get;
            set;
        }

        string GetItem(int index);
     
        void SetItem(int index, string value);

        void Add(string value);
    }
}
