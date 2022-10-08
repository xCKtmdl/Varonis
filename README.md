# Varonis Technical Interview Question

This is the question Veronis asked me for the coding interview for Escalation Engineer.

I ran the code through the Program.cs file, and not by unit test during
the interview.

I created the unit test for demonstration in this guide.

You are presented with some code:

```csharp
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
```

and presented some questions,

```csharp
/*
 * Technical Interview Question for Varonis Escalation Engineer
 *  1) what is questionOne() supposed to do?
 *  2) what is the bug(s)?
 *  3) how do you fix it?
 */
```

