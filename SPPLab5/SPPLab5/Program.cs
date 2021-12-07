using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace SPPLab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(Console.ReadLine());

            List<Type> types = assembly.GetTypes().ToList();
            types = types.Where(type => type.IsPublic).OrderBy(type => type.Namespace).ThenBy(type => type.Name).ToList();
            foreach (Type publicTypes in types)
                Console.WriteLine(publicTypes.ToString());
            Console.ReadLine();
        }
    }
}
