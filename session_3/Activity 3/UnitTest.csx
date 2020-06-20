decimal ParseAndCalculate(string command)
{
    string[] items = command.Split(' ');
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
    return result;
}

void RunTest(decimal actual, decimal expected)
{
    if (actual == expected)
    {
        Console.WriteLine("Pass");
    }
    else
    {
        Console.WriteLine("Failed");
    }
}

// Arrange
string commandOne = "1 + 2";
// Act
decimal result = ParseAndCalculate(commandOne);
// Assert
RunTest(result, 3)
