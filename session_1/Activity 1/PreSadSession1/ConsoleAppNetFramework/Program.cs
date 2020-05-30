﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var shouldWork = true;
            while (shouldWork)
            {
                var input = Console.ReadKey();
                if (input.KeyChar == 'e')
                {
                    Console.Write(" - Exiting....");
                    shouldWork = false;
                }
                else if (input.KeyChar == 'h')
                {
                    Console.Write(" - Enter your name:");
                    var name = Console.ReadLine();
                    Console.WriteLine($"Hi, {name}");
                }
                else
                {
                    Console.Write(" - Wrong command... Try again \n");
                }
            }
        }
    }
}
