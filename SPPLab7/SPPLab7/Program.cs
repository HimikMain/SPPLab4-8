using System;
using System.Threading;

namespace SPPLab7
{
    class Program
    {
        public delegate void Task(object done);
        public static void WaitAll(Task[] task)
        {
            ManualResetEvent[] doneEvents = new ManualResetEvent[task.Length];
            for (int i = 0; i < task.Length; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(new WaitCallback(task[i]),
                doneEvents[i]);
            }
            
            WaitHandle.WaitAll(doneEvents); 
            Console.WriteLine("All tasks are complete."); 
        }

        public static void PaintRect(object obj)
        {
            ManualResetEvent doneEvent = (ManualResetEvent)obj;
            Random rnd = new Random();
            int width = rnd.Next(2, 6);
            int height = rnd.Next(2, 6);
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++)
                    Console.Write("#");
                Console.WriteLine();
            }
            Console.WriteLine();
            doneEvent.Set();
        }

        static void Main(string[] args)
        {
            Task[] tasks = new Task[20];
            for (int i = 0; i < tasks.Length; i++)
                tasks[i] = PaintRect;
            WaitAll(tasks);
            Console.ReadKey();
        }
    }
}
