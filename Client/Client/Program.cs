using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = null;
            string username = null;
            NoLimit.Client.Client client;

            Console.WriteLine("Server address: ");
            address = Console.ReadLine();
            Console.WriteLine("Username: ");
            username = $"username|{Console.ReadLine()}";

            client = new NoLimit.Client.Client(address, 667);
            Console.WriteLine(client.send(username));

            Console.WriteLine("[ PRESS ENTER TO CLOSE ]");
            Console.ReadLine();

            client.disconnect();

        }
    }
}
