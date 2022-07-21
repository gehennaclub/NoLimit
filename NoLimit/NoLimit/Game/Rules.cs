using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoLimit.Game
{
    public class Rules
    {
        public Players players = new Players();
    
        public class Players
        {
            public static int minimum = 5;
        }

        public class Cards
        {
            public static int total = 7;
        }

        public class Win
        {
            public static int score = 10;
        }
    }
}
