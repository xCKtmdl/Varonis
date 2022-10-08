# Varonis Technical Interview Question

This is the question Varonis asked me for the coding interview for Escalation Engineer.

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

## 1) What is the method questionOne() supposed to do?

From reading the code it is obvious the intention is to build a list of 999
 integers, and then remove the integers in the range x: 201 > x > 99 (100-200).
 
The interviewer tells you it is a fact that the code has a bug, and the next step
is to find it.

## 2) What is/are the bug(s)?


The answer to 1) motivates the following simple test:

```csharp
        [TestMethod]
        public void TestMethod1()
        {
            var s = InterviewQuestion.questionOne();
            int count = s.Where(s => s > 99 && s < 201).Count();
            Assert.IsTrue(count == 0);
            
        }
```

Now this test passes, but is supposed to fail because of the fact about
 the bug the interviewer told us.
 
The reason it passes is because statistically it is unlikely to get numbers in
such a range from a uniform distribution of integers 0-1000000 in such a small
sample of 999 integers.

The interviewer allows you to change this line of code so you can see an example
of how the code is not operating as intended:

```charp
                numbers.Add(random.Next(200));
```

Now you can see that the test fails and how. You can also change the length of the list to something smaller than 999 for illustrative purpose.

Let's take this length 6 list for example.

5
\
18
\
115
\
182
\
300
\
400

When i=2, the code is supposed to remove 115, which it does. But now the incrementer
is incremented to i=3, and 182 which is supposed to be removed is now in the
numbers[2] spot and does not get checked/removed.

So the problem is with consecutive numbers in the range.

## 3) How do you fix the bug?

Here is the correction to the for loop:

```csharp
            for (int i=0;i<numbers.Count;)
            {
                if (numbers[i] > 99 && numbers[i] < 201)
                {
                    numbers.RemoveAt(i);
                }
                else
                    i++;
            }
```