using System;

namespace CalculationParser
{
    class Program
    {
        static void ParseElements(ref string[] items, string command){
                items = command.Split(' ');
        }
        static void Main(string[] args)
        {
            while (true)
            {
                var command = Console.ReadLine();
                // 8 + 2
                // 10 * 3
                // 10 / 2
                // 7 - 4
                string[] items = {};
                ParseElements(ref items, command);
                int firstNum = Int16.Parse(items[0]);
                char operant = char.Parse(items[1]);
                int secondNum = Int16.Parse(items[2]);
                decimal result = 0;
                switch (operant)
                {
                    case '+':
                        result = firstNum + secondNum;
                        break;
                    case '-':
                        result = firstNum - secondNum;
                        break;
                    case '*':
                        result = firstNum * secondNum;
                        break;
                    case '/':
                        result = firstNum / secondNum;
                        break;
                }
                Console.WriteLine("" + firstNum + operant + secondNum + '=' + result);
                
                Console.WriteLine("Click 'e' to exit or any other key to continue.");
                var input = Console.ReadKey();
                if (input.KeyChar == 'e')
                {
                    return;
                }
                Console.WriteLine("Continuing");
            }
        }
    }
}
