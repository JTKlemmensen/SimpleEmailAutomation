using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEmailAutomation.Entities
{
    public class DataRow
    {
        private Dictionary<string,string> Data { get; set; }
        
        public DataRow()
        {
            Data = new Dictionary<string, string>();
        }

        public string Value(string name)
        {
            return Data.ContainsKey(name) ? Data[name] : "";
        }

        public void SetField(string name, string value)
        {
            Data[name] = value;
        }
    }
}