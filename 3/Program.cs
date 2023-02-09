// Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
// 6, 1, 33 -> [6, 1, 33]
int[] numbersArray = new int[8];
int[] arrayCopy= new int[8];
int count = 0;
string stringNumber = "";
string message = "";
 
//This method output string message
void outPutStringMessge(string str = null, int x = 0){
   if(str==null && x==0)
      Console.WriteLine("-------------------------------------------------------------------");
   else if(str!=null && x==0){
      outPutStringMessge();
      Console.WriteLine(str);
   }else Console.WriteLine($"{str} {x}");
}
//This method fills an array with numbers.
void fillArrayNumbers(){
   outPutStringMessge("Please enter 0 for exit from cycle.");
   outPutStringMessge("Please enter the numbers: ");
   while(!stringNumber.Equals("0")){
      stringNumber = Console.ReadLine();
      if(count >= numbersArray.Length-1)
         Array.Resize(ref numbersArray, count+count/2);
      numbersArray[count] = int.Parse(stringNumber);
      count++;
   }
}

Console.Clear();
fillArrayNumbers();
message = "["+String.Join(", ", Array.FindAll(numbersArray, number => number !=0))+"]";
outPutStringMessge(message);

