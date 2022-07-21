using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoLimit.Logger
{
    public class Logs
    {
        public enum Type
        {
            information = 0,
            wait = 1,
            success = 2,
            error = 3,
            normal = 4,
            item = 5,
            received = 6,
            sent = 7
        }
        public string icon { get; set; }
        public ConsoleColor color { get; set; }
    }
}
