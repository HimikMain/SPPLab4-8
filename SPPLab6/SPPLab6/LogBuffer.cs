using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace SPPLab6
{
    public class LogBuffer
    {
        private List<string> myListToFile;
        private readonly int limitTime;
        private readonly int limitNumbOfItems;
        private static System.Timers.Timer timer;
        private readonly string path;
        private Mutex mt;

        public LogBuffer(int limitTime, int limitNumbOfItems)
        {
            this.limitTime = limitTime;
            this.limitNumbOfItems = limitNumbOfItems;
            path = @"C:\Labs\SPP\SPPLab6\SPPLab6\test.txt";
            myListToFile = new List<string>();
            mt = new Mutex();
            SetTimer();
        }

        public void Add(string item)
        {
            myListToFile.Add(item);

            if (myListToFile.Count >= limitNumbOfItems)
            {
                Thread SaveThread = new Thread(SaveToFile);
                SaveThread.Start();
            }
        }

        private void SaveToFile()
        {
            mt.WaitOne();
            if (myListToFile.Count != 0)
            {
                File.AppendAllLines(path, myListToFile);
                myListToFile.Clear();
            }
            mt.ReleaseMutex();
        }

        private void CallTimerSaveToFile(object source, System.Timers.ElapsedEventArgs e)
        {
            if (myListToFile.Count != 0)
            {
                SaveToFile();
            }
        }

        private void SetTimer()
        {
            timer = new System.Timers.Timer(limitTime);
            timer.Elapsed += CallTimerSaveToFile;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
    }
}
