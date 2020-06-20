// int[] Change(int[] arr)
// {
//     arr[0] = 2;
//     return arr;
// }
// // first example
// int[] array = { 10, 30 };
// int[] newArr = Change(array);
// Console.WriteLine(newArr[0]); // 2
// // second
// int[] array2 = { 9, 10 };
// Change(array2);
// Console.WriteLine(array2[0]); // 9

// // third
// int[] array3 = { 0, 0 };
// array3 = Change(array3);
// Console.WriteLine(array3[0]); // 2

// int[] initialArr = {0};
class ClassWithNumber
{
    public int Number { get; set; }
}
struct StructWithNumber
{
    public int Number { get; set; }
}

var structSample = new StructWithNumber();
var classSample = new ClassWithNumber();
structSample.Number = 0;
classSample.Number = 0;
static void ChangeValue(ClassWithNumber classInstance, ref StructWithNumber stuctInstance)
{
    classInstance.Number = 100;
    stuctInstance.Number = 100;
}
ChangeValue(classSample, ref structSample);
Console.WriteLine(classSample.Number);
Console.WriteLine(structSample.Number);