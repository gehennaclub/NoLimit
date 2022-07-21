using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoLimit.Game
{
    public class Question
    {
        public string description { get; set; }

        public Question(string description)
        {
            this.description = description;
        }
    }
}
