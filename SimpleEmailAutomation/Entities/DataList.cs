using Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEmailAutomation.Entities
{
    public class DataList
    {
        public List<DataRow> DataRows { get; set; }

        public DataList(string uri)
        {
            DataRows = new List<DataRow>();

            var csv = File.ReadAllText(uri);
            foreach (var line in CsvReader.ReadFromText(csv))
            {
                DataRow row = new DataRow();

                foreach (var h in line.Headers)
                    row.SetField(h, line[h]);

                DataRows.Add(row);
            }
        }
    }
}