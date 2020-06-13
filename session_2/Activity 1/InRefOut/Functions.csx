// int Add(int a, int b){
//     return a + b;
// }
// int a = 1;
// int b = 2;
// Console.WriteLine($"a+b={Add(a,b)}");

// int integerOne = 0; // value type immutable
// // in
// void changeInt(ref int integerOne){
//    Console.WriteLine("Side effect.");
//    integerOne += 1;
// }

// Console.WriteLine(integerOne);
// changeInt(ref integerOne);
// Console.WriteLine(integerOne);



// void MustChangeInt(out int integer){
//    Console.WriteLine("Side effect.");
//    integer = 10;
// }
// int integerTwo;
// Console.WriteLine(integerTwo);
// MustChangeInt(out integerTwo);
// Console.WriteLine(integerTwo);

// class Book{
//     public string Name{get;set;}
// }

// Book newBook = new Book();
// newBook.Name = "Rubayyat";
// void changeBook(in Book book){
//     book.Name = "Think and Grow Rich";
// }
// Console.WriteLine(newBook.Name);
// changeBook(newBook);
// Console.WriteLine(newBook.Name);

// in ref out

// string initialString = "old";
// void changeStr(string str){
//     str += "~~mutation";
//     Console.WriteLine($"old:{initialString} | new:{str}");
// }

// Console.WriteLine(initialString);
// changeStr(initialString);
// Console.WriteLine(initialString);

// int[] initialArr = {0};
// void changeArr(int[] arr){
//     int[] new_arr = {1,2,3};
//     arr = new_arr;
// }

// Console.WriteLine(initialArr[0]);
// changeArr(initialArr);
// Console.WriteLine(initialArr[0]);

// string str = "abcd";
// str[1] = "x";

int a = 1;
void ChangeInt(){
    a += 1;
}
Console.WriteLine(a);
ChangeInt();
Console.WriteLine(a);