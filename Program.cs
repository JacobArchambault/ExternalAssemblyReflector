﻿using System;
using System.Reflection;

namespace ExternalAssemblyReflector
{
    class Program
    {
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Types in Assembly *****");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
                Console.WriteLine("Type: {0}", t);
            Console.WriteLine();
        }
        static void Main()
        {
            Console.WriteLine("***** External Assembly Viewer *****");
            do
            {
                Console.WriteLine("\nEnter an assembly to evaluate");
                Console.Write("or enter Q to quit: ");

                // Get name of assembly.
                string asmName = Console.ReadLine();

                // Does user want to quit?
                if (asmName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    break;
                // Try to load assembly.
                try
                {
                    Assembly asm = Assembly.Load(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch
                {
                    Console.WriteLine("Sorry, can't find assembly.");
                }
            }
            // Does user want to quit?
            while (true);
        }
    }
}
