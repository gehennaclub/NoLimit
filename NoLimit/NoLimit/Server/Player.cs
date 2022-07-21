using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NoLimit.Server
{
    public class Player
    {
        private TcpClient client { get; set; }
        public string id { get; set; }
        public string username { get; set; }
        private int points { get; set; }
        private bool is_boss { get; set; }
        public List<Game.Card> cards { get; set; }
        public Game.Question question { get; set; }
        private Random random = new Random();
        private NetworkStream stream { get; set; }
        private Logger.Logger logger { get; set; }
        public enum State
        {
            running = 0,
            won = 1,
            lose = 2
        }
        public State status { get; set; }

        public Player(TcpClient client)
        {
            this.client = client;
            this.id = $"Player: {client.Client.RemoteEndPoint}".Split(':')[2];
            this.points = 0;
            this.cards = load_cards();
            stream = client.GetStream();
            logger = new Logger.Logger();
        }

        public void play()
        {
            status = State.running;
        
            while (status != State.running)
            {
                if (cards.Count < Game.Rules.Cards.total)
                {
                    draw();
                }
                logger.display($"{username}: {read()}", Logger.Logs.Type.received);
            }
        }

        private List<Game.Card> load_cards()
        {
            List<Game.Card> cards = new List<Game.Card>();

            for (int i = 0; i < Game.Rules.Cards.total; i++)
            {
                cards.Add(Game.Resources.answers[random.Next(Game.Resources.answers.Count)]);
            }

            return (cards);
        }

        public void disconnect()
        {
            stream.Close();
            client.Client.Disconnect(true);
            client.Close();
        }

        public void boss(bool state)
        {
            is_boss = state;
        }

        public bool wins()
        {
            return (points >= Game.Rules.Win.score);
        }

        public void send(string data)
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

            stream.Write(msg, 0, msg.Length);
        }

        public string read()
        {
            string response = null;
            byte[] data = new byte[Settings.buffer];
            Int32 bytes = stream.Read(data, 0, data.Length);

            response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            
            return (response);
        }

        public void draw()
        {
            if (is_boss == true)
            {
                draw_question();
            } else
            {
                cards.Add(Game.Resources.answers[random.Next(Game.Resources.answers.Count)]);
            }
        }

        public void place(Game.Card card)
        {
            cards.RemoveAt(cards.IndexOf(card));
        }

        public void draw_question()
        {
            question = (Game.Resources.questions[random.Next(Game.Resources.questions.Count)]);
        }

        public void draw_card()
        {
            cards.Add(Game.Resources.answers[random.Next(Game.Resources.answers.Count)]);
        }
    }
}
