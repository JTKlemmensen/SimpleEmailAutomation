using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEmailAutomation.Entities
{
    public class Settings
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Host { get; set; }
        public static int Port { get; set; }
    }
}