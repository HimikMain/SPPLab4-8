using System;

namespace SPPLab6
{
    class Program
    {
        static void Main(string[] args)
        {
            LogBuffer logBuffer = new LogBuffer(3000, 50);
            for (int i = 0; i < 10000; i++)
            {
                logBuffer.Add(i.ToString());
            }
        }
    }
}
