using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VaronisTests")]

/*
 * Technical Interview Question for Varonis Escalation Engineer
 *  1) what is questionOne() supposed to do?
 *  2) what is the bug(s)?
 *  3) how do you fix it?
 */

namespace Varonis
{
    internal class InterviewQuestion
    {
        public static List<int> questionOne()
        {
            List<int> numbers = new List<int>();

            Random random = new Random();
            for (int i=0;i<999;i++)
            {
                numbers.Add(random.Next(1000000));
            }

            for (int i=0;i<numbers.Count;i++)
            {
                if (numbers[i] > 99 && numbers[i] < 201)
                {
                    numbers.RemoveAt(i);
                }
            }

            return numbers;
        }
    }
}
