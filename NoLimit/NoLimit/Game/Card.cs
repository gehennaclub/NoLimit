using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoLimit.Game
{
    public class Card
    {
        public string description { get; set; }

        public Card(string description)
        {
            this.description = description;
        }
    }
}
