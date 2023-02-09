// Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12
string stringNumber = null;
int[] numbersArray;
int lengthNumber = 0;
int sumResult = 0;
int number = 0;
int x = 0;
int j = 0;
    
//This method output string message
void outPutStringMessge(string str = null, int x = 0){
   if(str==null && x==0)
      Console.WriteLine("-------------------------------------------------------------------");
   else if(str!=null && x==0){
      outPutStringMessge();
      Console.Write(str);
   }else Console.WriteLine($"{str} {x}");
}
//This method calculate sum numbers of number
void numberSumCalculator(int number){
   while(x==0){
      if(number!=0){
         lengthNumber = (int)Math.Pow(10,stringNumber.Length-1);
         numbersArray = new int[stringNumber.Length]; 
         for(int i = lengthNumber; 1<=i; i/=10, j++){
            numbersArray[j] = number/i;
            number -= numbersArray[j]*i; 
            sumResult += numbersArray[j];
         }
         outPutStringMessge("Result: ", sumResult);
         x=1; 
      } else outPutStringMessge("Number haven't to equals  0 !!!\n");
   }    
}
    
Console.Clear();
outPutStringMessge("Please enter the number: ");
stringNumber = Console.ReadLine();
number = int.Parse(stringNumber);
numberSumCalculator(number);
