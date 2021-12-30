using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using ExportAttribute;

namespace SPPLab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(Assembly.GetExecutingAssembly().Location);

            List<Type> types = assembly.GetTypes().Where(t => t.IsPublic).OrderBy(type => type.Namespace).ThenBy(type => type.Name).ToList();

            Console.WriteLine("ExportClasses: ");
            foreach (var type in types)
            {
                if (Attribute.GetCustomAttribute(type, typeof(ExportClass)) != null)
                {
                    Console.WriteLine(type.FullName);
                }
            }
        }
    }

    [ExportClass]
    public class PublicClass { }
}

namespace Classes
{
    [ExportClass]
    public class PublicClass { }

    [ExportClass]
    internal class InternalClass { }

    public class SecondPublicClass { }
}