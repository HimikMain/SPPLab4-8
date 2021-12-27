using System;

namespace SPPLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            OSHandle test = new OSHandle(IntPtr.Zero);
            Console.WriteLine(test.Handle);
            test.Dispose();
            Console.WriteLine(test.Handle);
            Console.ReadLine();
        }
    }
}
