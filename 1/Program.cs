//
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