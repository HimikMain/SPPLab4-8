using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPLab9
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 1; i <= 10; i++) 
            {
                list.Add(i);
            }

            Console.Write("Лист: ");
            foreach (int element in list)
            {
                Console.Write(element + ",");
            }
            Console.WriteLine("\nРазмер: " + list.count);

            list.RemoveAt(1);
            Console.Write("Лист: ");
            foreach (int element in list)
            {
                Console.Write(element + ",");
            }
            Console.Write("\nРазмер: ");
            Console.WriteLine(list.count);

            list.Clear();

            Console.Write("Лист: ");
            foreach (int element in list)
            {
                Console.Write(element + ",");
            }
            Console.Write("\nРазмер: " + list.count);
        }
    }
}
