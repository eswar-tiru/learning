
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace SimpleCOMList
{
    [Guid("ea2acf77-e3b1-4d24-b71b-535aed12e6e3")]
    [ComVisible(true)]
    [ProgId("ProgId.SimpleCOMList")]
    public class StringList : IStringList
    {
        private List<string> _items;

        public StringList()
        {
            _items = new List<string>();
        }

        public string this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public string GetItem(int index)
        {
            return _items[index];
        }

        public void SetItem(int index, string value)
        {
            _items[index] = value;
        }

        public void Add(string value)
        {
            _items.Add(value);
        }
    }
}
