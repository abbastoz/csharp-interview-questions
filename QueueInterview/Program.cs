
using System;
using System.Collections.Generic;
namespace CsharpInterviewQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
            PhotoBook po1 = new PhotoBook();
            po1.GetNumberPages();
            PhotoBook po2 = new PhotoBook(24);
            po2.GetNumberPages();
            BigPhotoBook bpo1 = new BigPhotoBook();
            bpo1.GetNumberPages();

            Person p1 = new Person();
            Console.WriteLine(p1.Greet());
            Student s1 = new Student();
            s1.SetAge(21);
            Console.WriteLine(s1.Greet());
            Console.WriteLine(s1.ShowAge());
            Console.WriteLine(s1.Study());
            Teacher t1 = new Teacher();
            t1.SetAge(45);
            Console.WriteLine(t1.Greet());
            Console.WriteLine(t1.Explain());

            int[] B = new int[] { 25, 2, 3, 57, 38, 41 };
            int [] aa= solve(B);
            Console.WriteLine(solution(29).ToString());
            int[] A = new int[] { 10, -10, -1, -1, 10 };
            int a = solution(A);
            Console.WriteLine(LongestBeautifulStringInOrder("abcdeaeiaaioaaaaeiiiiouuuooaauuaeiu"));
            MinStack myMin = new MinStack();
            int y = myMin.top();
            Console.WriteLine(y.ToString());
            int x = myMin.getMin();
            Console.WriteLine(x.ToString());
            myMin.push(1);
            myMin.push(2);
            myMin.push(3);
            myMin.push(4);

            y = myMin.top();
            Console.WriteLine(y.ToString());
            myMin.pop();
            y = myMin.top();
            Console.WriteLine(y.ToString());
            QueueWithStackClass<string> myQue = new QueueWithStackClass<string>();
            myQue.enqueue("apple");
            myQue.enqueue("banana");
            myQue.enqueue("orange");
            Console.WriteLine("--Elements after enqueue");
            foreach (var obj in myQue.QueueElements())
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("dequee:" + myQue.dequeue());
            myQue.enqueue("watermelon");
            Console.WriteLine("--Elements after dequeue and enqueue ");
            foreach (var obj in myQue.QueueElements())
            {
                Console.WriteLine(obj);
            }

            StackWithQueueClass<int> myStck = new StackWithQueueClass<int>();
            myStck.push(1);
            myStck.push(5);
            myStck.push(10);
            Console.WriteLine("After Push");
            foreach (var obj in myStck.StackElements())
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("Poped element: " + myStck.pop().ToString());
            Console.WriteLine("After Pop");
            foreach (var obj in myStck.StackElements())
            {
                Console.WriteLine(obj);
            }
            Console.ReadKey();
        }
        static int solution(int n)
        {
            if (10 > n || n > 99) return 0;
            string a = n.ToString();            
            int result = Convert.ToInt32(a[0]) + Convert.ToInt32(a[1]);
            return result;

        }

        static int[] solve(int[] a)
        {           
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            for (int i=0; i<a.Length; i++)
            {
                if (a[i] < 10 ) {
                    if (keyValuePairs.TryGetValue(a[i], out _))
                    {
                        keyValuePairs[a[i]]++;
                    }
                    else keyValuePairs.Add(a[i], 1);
                }
                else
                {
                    int m, n;
                    n = a[i];
                    while (n > 0)
                    {
                        m = n % 10;
                        if (keyValuePairs.TryGetValue(m, out _))
                        {
                            keyValuePairs[m]++;
                        }
                        else keyValuePairs.Add(m, 1);
                        n /= 10;
                    }
                }
            }
            int max =0;
            foreach(var item in keyValuePairs)
            {
                if (item.Value > max) max = item.Value;
            }

            List<int> result= new List<int>();
            foreach(var item in keyValuePairs)
            {
                if (item.Value == max) result.Add(item.Key);
            }

            int[] xx = result.ToArray();
            
            Array.Sort(xx);
            return xx;
        } 
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = A[0], count = 0, length = A.Length;
            for (int i = 0; i < length; i++)
            {
                
                if (i + 1 < length)
                {
                    result += A[i + 1];
                   
                    if (result < 0 && i > 0)
                    {
                        if (A[i - 1] < A[i])
                        {
                            List<int> list = new List<int>(A);
                            int tmp = A[i - 1];
                            list.RemoveAt(i - 1);
                            list.Add(tmp);
                            A = list.ToArray();
                            count++;
                            i = -1;
                        }
                    }
                }
            }
            return count;
        }

        public static string LongestBeautifulStringInOrder(string word)
        {

            // code goes here              
            List<char> lists = new List<char>();            
            string s = "aeiou";
            lists.AddRange(s);
            

            int index = 0;
            int len = 0;
            int max = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == lists[index])
                    len++;
                else if ((len > 0) && (index + 1 < lists.Count) && (word[i] == lists[index + 1]))
                {
                    index++;
                    len++;
                }
                else
                {
                    if (index == 4)
                    {
                        if (len > max)
                            max = len;
                    }

                    index = 0;
                    len = 0;

                    if (word[i] == lists[0])
                        len = 1;
                }
            }

            if (index == 4)
            {
                if (len > max)
                    max = len;
            }

            return max.ToString();

        }
        

    }


    public class QueueWithStackClass<T>
    {
        Stack<T> s1 = new Stack<T>();
        Stack<T> s2 = new Stack<T>();

        public void enqueue(T fruit)
        {
            //if stack1 has elements move them to stack2
            while (s1.Count > 0)
            {
                s2.Push(s1.Pop());
            }
            //add to stack, the next will be on the down.    
            s1.Push(fruit);

            //add all back to stack1
            while (s2.Count > 0)
            {
                s1.Push(s2.Pop());
            }
        }

        public T dequeue()
        {
            //check if Queue has elements
            if (s1.Count < 0) return default(T);
            T x = (T)s1.Peek();
            s1.Pop();
            return x;
        }
        public Stack<T> QueueElements()
        {
            return s1;
        }
    }
    public class StackWithQueueClass<T>
    {
        Queue<T> q1 = new Queue<T>();
        Queue<T> q2 = new Queue<T>();

        public void push(T number)
        {
            //push new element to q2;
            q2.Enqueue(number);
            //move all elements to q2 from q1
            while (q1.Count > 0)
            {
                T x = (T)q1.Peek();
                q2.Enqueue(x);
                q1.Dequeue();
            }
            //change queues
            Queue<T> q = q1;
            q1 = q2;
            q2 = q;
        }
        public T pop()
        {
            //pop element as it queue is ordered as LIFO
            if (q1.Count < 1) return default(T);
            T x = (T)q1.Peek();
            q1.Dequeue();
            return x;
        }

        public Queue<T> StackElements()
        {
            return q1;
        }
    }
    public class StackWithLinkedList<T>
    {

    }
    public class MinStack
    {
        int topElement;
        List<int> myStack;
        public MinStack()
        {
            this.myStack = new List<int>();
        }
        public void push(int x)
        {
            myStack.Add(x);
        }
        public void pop()
        {
            if (myStack.Count > 0)
                myStack.RemoveAt(myStack.Count - 1);
        }
        public int top()
        {
            if (myStack.Count > 0)
                topElement = myStack[myStack.Count - 1];
            return topElement;
        }
        public int getMin()
        {
            if (myStack.Count < 1) return 0;
            int minElement = myStack[0];
            foreach (var obj in myStack)
            {
                if (minElement > obj)
                    minElement = obj;
            }
            return minElement;
        }
    }
}
