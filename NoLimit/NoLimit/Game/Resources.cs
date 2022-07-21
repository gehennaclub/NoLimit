using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoLimit.Game
{
    public class Resources
    {
        public static List<Card> answers = new List<Card>()
        {
            new Card("test_0"),
            new Card("test_1"),
            new Card("test_2"),
            new Card("test_3"),
            new Card("test_4"),
            new Card("test_5"),
            new Card("test_6"),
            new Card("test_7"),
            new Card("test_8"),
            new Card("test_9"),
            new Card("test_10")
        };

        public static List<Question> questions = new List<Question>()
        {
            new Question("Question_test_0"),
            new Question("Question_test_1"),
            new Question("Question_test_2"),
            new Question("Question_test_3"),
            new Question("Question_test_4"),
            new Question("Question_test_5"),
            new Question("Question_test_6"),
            new Question("Question_test_7"),
            new Question("Question_test_8"),
            new Question("Question_test_9"),
            new Question("Question_test_10")
        };
    }
}
