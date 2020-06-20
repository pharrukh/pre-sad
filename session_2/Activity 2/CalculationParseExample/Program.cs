using System;

namespace CalculationParseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // string initialString = "old";
            // void changeStr(ref string str){
            //     str += "~~mutation";
            //     Console.WriteLine($"old:{initialString} | new:{str}");
            // }

            // Console.WriteLine(initialString);
            // changeStr(ref initialString);
            // Console.WriteLine(initialString);

            int[] initialArr = {0};
            void changeArr(int[] arr){
                arr[0] = 1;
            }

            Console.WriteLine(initialArr);
            changeArr(initialArr);
            Console.WriteLine(initialArr);
        }
    }
}
