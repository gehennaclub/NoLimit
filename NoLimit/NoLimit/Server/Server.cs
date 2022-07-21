using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoLimit.Server
{
    public class Server
    {
        private TcpListener server { get; set; }
        private Int32 port = 667;
        private IPAddress address { get; set; }
        private byte[] buffer = new byte[512];
        private string data { get; set; }
        private Logger.Logger logger { get; set; }
        public enum State
        {
            stopped = 0,
            running = 1,
            loading = 2,
            waiting = 3,
            finished = 4
        };
        public State status { get; set; }
        private List<Player> players { get; set; }

        public Server()
        {
            status = State.loading;
            players = new List<Player>();
            address = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(IPAddress.Any, port);
            logger = new Logger.Logger();

            banner();
            about();

            server.Start();
            load();
            play();
            server.Stop();
        }

        private void banner()
        {
            Console.WriteLine(" _____     __    _       _ _              _ ");
            Console.WriteLine("|   | |___|  |  |_|_____|_| |_    ___ ___|_|");
            Console.WriteLine("| | | | . |  |__| |     | |  _|  | .'| . | |");
            Console.WriteLine("|_|___|___|_____|_|_|_|_|_|_|    |__,|  _|_|");
            Console.WriteLine("            Developed by neo         |_|  \n");
        }

        private void about()
        {
            logger.display($"NoLimit server informations: ", Logger.Logs.Type.information);
            logger.display($"server local address: '127.0.0.1'", Logger.Logs.Type.item);
            logger.display($"server public address: '{Informations.ip()}'", Logger.Logs.Type.item);
            logger.display($"server port: {port}", Logger.Logs.Type.item);

            logger.display("", Logger.Logs.Type.normal);
        }

        private void load()
        {
            TcpClient client = new TcpClient();
            bool bypass = true;

            status = State.waiting;
            logger.display("Waiting for players", Logger.Logs.Type.wait);

            while (status == State.waiting)
            {
                if (players.Count >= Game.Rules.Players.minimum || (bypass == true && players.Count == 1))
                {
                    logger.display($"starting a new game", Logger.Logs.Type.wait);
                    status = State.running;
                } else
                {
                    logger.display($"lobby: {players.Count}/{Game.Rules.Players.minimum}", Logger.Logs.Type.normal);
                    client = server.AcceptTcpClient();
                    players.Add(new Player(client));
                    Thread t = new Thread(new ParameterizedThreadStart(manager));
                    t.Start(players.Count - 1);
                }
            }
        }

        private void play()
        {
            logger.display("starting new game", Logger.Logs.Type.wait);

            while (status == State.running)
            {
                logger.display("playing", Logger.Logs.Type.wait);
                foreach (Player p in players)
                {
                    logger.display($"Player {p.id}:", Logger.Logs.Type.information);
                    logger.display($"Question: {p.question}", Logger.Logs.Type.item);
                    foreach (Game.Card c in p.cards)
                    {
                        logger.display($"{c.description}", Logger.Logs.Type.item);
                    }
                }
                status = State.stopped;
            }
            Console.ReadKey();
        }

        private void init_player(int index)
        {
            players[index].send(Settings.Server.response);
            logger.display($"initializating player '{players[index].id}'", Logger.Logs.Type.wait);
            logger.display($"{players[index].read()} joined", Logger.Logs.Type.item);
            players[index].send(Settings.Server.init);
        }

        public void manager(object index_obj)
        {
            int index = (int)index_obj;

            init_player(index);
            players[index].play();
        }
    }
}
