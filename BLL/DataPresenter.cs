using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class DataPresenter
    {
        public int Index { get; }
        public Dictionary<string, string> Data { get; }

        public DataPresenter(int index = 0)
        {
            Index = index;
            Data = new Dictionary<string, string>();
        }

        public DataPresenter SetData(string key, string value)
        {
            Data.Add(key, value);
            return this;
        }

        public override string ToString()
        {
            return $"{Index}) " + Data.Aggregate("", (current, item) => current + $"{item.Value}\n");
        }
    }
}