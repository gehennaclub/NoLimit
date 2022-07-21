using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NoLimit.Client
{
    public class Client
    {
        private string server { get; set; }
        private Int32 port { get; set; }
        private TcpClient client { get; set; }
        private NetworkStream stream { get; set; }

        public Client(string server, Int32 port)
        {
            this.server = server;
            this.port = port;
            client = new TcpClient(server, port);
            stream = client.GetStream();
        }

        public string send(string message)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            stream.Write(data, 0, data.Length);

            return (read());
        }

        public string read()
        {
            string response = null;
            byte[] data = new byte[Settings.buffer];
            Int32 bytes = stream.Read(data, 0, data.Length);

            response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

            return (response);
        }

        public void disconnect()
        {
            stream.Close();
            client.Close();
        }
    }
}
