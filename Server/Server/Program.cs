using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            NoLimit.Server.Server server = new NoLimit.Server.Server();

            Console.WriteLine(server.status);
        }
    }
}
