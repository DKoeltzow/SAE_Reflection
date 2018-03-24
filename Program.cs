using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        private static List<object> objects = new List<object>();

        static void Main(string[] args)
        {
            ShowClasses();

            objects.Add(new Knight());
            objects.Add(new Archer());
            

            InvokeUnknownMethodByName();
            
            Console.Read();
        }

        private static void ShowClasses()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.IsAbstract)
                {
                    Console.WriteLine(type.Name);
                }
            }
        }

        private static void InvokeUnknownMethodByName()
        {
            foreach (var item in objects)
            {
                Type type = item.GetType();
                MethodInfo mInfo = type.GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic);
                if (mInfo != null)
                {
                    mInfo.Invoke(item, null);
                }
            }
        }
    }
}
