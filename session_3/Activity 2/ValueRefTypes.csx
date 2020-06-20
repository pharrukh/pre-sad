// Example # 1
void RunExample0()
{
    int[] array = { 1, 2, 3, 4, 5 };
    Console.WriteLine(array[1]);
    Console.WriteLine(array[4]);
    int a = 10;
    Console.WriteLine(a);
    a += 20;
    Console.WriteLine(a);
    string str = "abcdef";
    Console.WriteLine(str);
    str += "x";
    Console.WriteLine(str);
}

// Add two values and print the result
void RunAddAndPrint()
{
    int a = 10;
    int b = 20;
    int c = a + b;
    Console.WriteLine(c);
}

// Concatinate two strings
void RunTakeTwoStringsAndConcatinateThem()
{
    string str1 = "a";
    string str2 = "b";
    string str3 = str1 + str2;
    Console.WriteLine(str3);
}

// Update value in an array
void RunUpdateFirstValueInArray()
{
    string[] arr = { "ab", "cd", "ef" };
    arr[0] = "xz";
    Console.WriteLine(arr[0]);
}

// Example of value type
void RunExample1()
{
    void ChangeInt(int num)
    {
        num = 20;
    }
    var a = 10;
    ChangeInt(a);
    Console.WriteLine(a);
}

// Example of ref type
void RunExample2()
{
    void ChangeArray(int[] array)
    {
        array[0] = 10;
    }
    int[] arr = { 1, 2, 3, 4, 5 };
    ChangeArray(arr);
    Console.WriteLine(arr[0]);
}