using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEmailAutomation.Entities
{
    public class MessageTemplate
    {
        public string Template { get; set; }
        private Dictionary<string, KeyWord> Keywords { get; set; }

        public MessageTemplate()
        {
            Keywords = new Dictionary<string, KeyWord>();
        }

        public string Message(DataRow row)
        {
            if (Template == null)
                return "";

            string message = Template;

            foreach(KeyValuePair<string, KeyWord> keyword in Keywords.ToArray())
                message = message.Replace(keyword.Key, row.Value(keyword.Value.Value));


            return message;
        }

        public void SetKeywod(string identifier, string value, bool isDynamic)
        {
            Keywords[identifier] = new KeyWord { Value = value, IsDynamic = isDynamic };
        }

        public KeyWord GetKeyword(string identifier)
        {
            return Keywords.ContainsKey(identifier) ? Keywords[identifier] : new KeyWord { Value="",IsDynamic=false};
        }
    }
}