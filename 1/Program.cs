//Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16

Console.Clear();
Console.WriteLine("Please enter the number and degree to raise a number to a power");
Console.WriteLine("-------------------------------------------------------------------");
int x=0;
while(x==0){
   Console.Write("Please enter the number: ");
   int number = int.Parse(Console.ReadLine());
   Console.WriteLine("-------------------------------------------------------------------");
   if(number!=0){
      Console.Write("Please enter a power: ");
      int power = int.Parse(Console.ReadLine());
      Console.WriteLine("------------------------------------------------------------------- ");
      double result = Math.Pow(number,power);
      Console.WriteLine($"Result: {result}");
      Console.WriteLine("------------------------------------------------------------------- ");
      x=1; 
   } else Console.WriteLine("Number haven't to equals  0 !!!");
}