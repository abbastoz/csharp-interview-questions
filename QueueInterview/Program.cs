
using System;
using System.Collections.Generic;
namespace QueueInterview
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("dequee:"+myQue.dequeue());         
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
       public  void push(int x)
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



    

