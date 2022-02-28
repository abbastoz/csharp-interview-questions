
using System;
using System.Collections.Generic;
namespace QueueInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueClass<string> myQue = new QueueClass<string>();
            myQue.enqueue("apple");
            myQue.enqueue("banana");
            myQue.enqueue("orange");
            Console.WriteLine("--Elements after enqueue");
            foreach (var obj in myQue.QueueElements())
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("dequee:"+myQue.dequeue());         
            myQue.enqueue("watermelon");
            Console.WriteLine("--Elements after dequeue and enqueue ");
            foreach (var obj in myQue.QueueElements())
            {
                Console.WriteLine(obj);
            }

            StackClass<int> myStck = new StackClass<int>();
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
    }
    public class QueueClass<T>
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
    public class StackClass<T>
    {
        Queue<T> q1 = new Queue<T>();
        Queue<T> q2 = new Queue<T>();

        public void push(T number)
        {
            q2.Enqueue(number);
            while (q1.Count > 0)
            {
                T x = (T)q1.Peek();
                q2.Enqueue(x);
                q1.Dequeue();
            }
            Queue<T> q = q1;
            q1 = q2;
            q2 = q;
        }
        public T pop()
        {
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
}
