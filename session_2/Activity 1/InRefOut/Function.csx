// this is c# script file
// perfect way to test ideas
// https://itnext.io/hitchhikers-guide-to-the-c-scripting-13e45f753af9
// run this file by calling 
// > csi Function.csx 
int add(int a, int b){
    return a + b;
}
int a = 1;
int b = 2;
Console.WriteLine($"a:(a) + b:(b) = {add(a,b)}");

string str = "test";
// why to use "in" 
// https://stackoverflow.com/a/52825832/3407539
void changeStr(in string str)
{
    Console.WriteLine($"str: {str}");
}
changeStr(str);

int year = 2020;
void mayChange(ref int year){
    year += 1;
    Console.WriteLine(year);
}
mayChange(ref year);
Console.WriteLine(year);
void normalFunc(int year){
    year += 1;
    Console.WriteLine(year);
}
normalFunc(year);
Console.WriteLine(year);

void CalculateArea(int a, int b, out int area){
    area = a * b;
}
int area = 1;
CalculateArea(10,20, out area);
Console.WriteLine(area);

