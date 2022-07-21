using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoLimit
{
    public class Settings
    {
        public static int buffer = 512;
        public static int listen = 10;

        public Server server = new Server();
        public Client client = new Client();

        public class Server
        {
            public static string init = "client successfully initialized";
            public static string response = "message successfully received";
        }

        public class Client
        {
            
        }
    }
}
