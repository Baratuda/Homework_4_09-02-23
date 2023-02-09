// Володя написал программу, которая складывает в столбик два числа. К сожалению, он не разобрался, 
// как правильно переносить единицу из одного разряда в следующий. Поэтому программа стала выполняться следующим образом. 
// Сначала она складывает последние цифры обоих чисел и записывает результат, как в случае, если он однозначный, так и в случае, 
// если он двузначный. Затем программа складывает предпоследние цифры обоих чисел и результат сложения приписывает слева к результату 
// предыдущего сложения. Далее процесс повторяется для всех разрядов. Если в одном числе цифр меньше, чем в другом, то программа размещает 
// нули в соответствующих разрядах более короткого числа.
// Федя хочет доказать Володе, что его способ сложения не обладает свойством ассоциативности. 
// В частности, Федя утверждает, что существуют три числа, для которых важен порядок, в котором их складывают (при этом разрешается 
// складывать числа в любом порядке, например можно сначала сложить первое число и последнее, а затем прибавить к ним среднее). 
// Федя привел даже пример трех таких чисел.

// Требуется написать программу, которая поможет Феде и Володе определить, верно ли утверждение, что, складывая заданные три числа в 
// разном порядке, можно получить разные суммы.

// Входные данные
// Входной файл INPUT.TXT содержит в одной строке три целых числа a, b и c (1 ≤ a, b, c ≤ 106). Все числа в строке разделены пробелом.

// Выходные данные
// В первую строку выходного файла OUTPUT.TXT необходимо вывести слово YES, если данные три числа можно сложить разными способами и 
// получить разные суммы. В противном случае, необходимо вывести слово NO.В последующих строках необходимо вывести все возможные суммы, 
// которые можно получить, складывая числа a, b и c. Суммы следует выводить по одной на строке и в порядке их возрастания.

//| №	INPUT.TXT	 | OUTPUT.TXT|
//|----------------------------|
//| 1	30 239 566	 | YES       |
//|                | 7945      |
//|                | 71215     |
//|----------------------------|
//|2	643 733 553	 | NO        |
//|                | 18129     |
//|----------------------------|


Console.Clear();
int СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED = 4;
int[] resultArray = new int[СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED];
string[] stringNumbersArray = new string[СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED];
int[][] twoDimensionalArrayNumbers = new int[СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED][];
int count = 0;
string? subString = null;

//This method output string message
void outPutStringMessge(string? str = null, int x = 0){
   if(str==null && x==0)
      Console.WriteLine("-------------------------------------------------------------------");
   else if(str!=null && x==0){
         outPutStringMessge();
         Console.WriteLine(str);
   }else Console.WriteLine($"{str} {x}");
}
    
//This method separate of the number by numbers and adds them in array.
int[]  separatorOfNumberBySubNumbers(string stringNumber){
      int[] numbersArray = new int[stringNumber.Length];
      int lengthNumber = (int)Math.Pow(10,stringNumber.Length-1); 
      int number = int.Parse(stringNumber); 
      int j=0;
      for(int i = lengthNumber; 1<=i; i/=10, j++){
         numbersArray[j] = number/i;
         number -= numbersArray[j]*i; 
      }
   return numbersArray;
}

//This method fills our two-dimensional array with arrays.
int[][] fillArrayNumbers(string[] stringNumbers){
   int[][] twoDimensionalArray = new int[СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED][];
   for(int i = 0; i<СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED; i++){
      twoDimensionalArray[i] =  separatorOfNumberBySubNumbers(stringNumbers[i]);
   }
   return twoDimensionalArray; 
}

//При изучении условия задачи я заметил закономерность в последовательности сложения чисел. 
//Пример: в нашем случае мы используем три числа (1,2,3) сначала мы складываем (1+2)+3, далее мы меняем  последовательность и 
//складываем (2+3)+1, а потом складываем аналагично (3+1)+2, из примера можно увидеть, что элементы последовательности смещаются 
//на один знак влево и данный метод смещает массив на один элемент влево, 
//используя этот метод можно поменять колличество введеных чисел(с 3 на 5)  и 
//задача не сломается.(доп. задача к 4-му ДЗ).    
int[][] arrayMixerOneElementToTheLeft(int[][] arrayNumbers){
   int[][] shiftedArray = new int[СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED][];
   for(int i = arrayNumbers.Length-1; 0<=i; i--){
      if(i==0)
         shiftedArray[arrayNumbers.Length-1] = arrayNumbers[i];
      else 
         shiftedArray[i-1] = arrayNumbers[i];
      }
   return shiftedArray;
}  

//This method output results.
void outputResult(int c){      
   if(c > 1){
      Array.Sort(resultArray);
      outPutStringMessge("Yes");
      for(int i = 0; i<СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED; i++)
         if(resultArray[i]!=0)outPutStringMessge("",resultArray[i]);
   }else{
      outPutStringMessge();
      outPutStringMessge("No\n",resultArray[0]);
   }
   outPutStringMessge(); 
}

//This method in
string methodOfIncorrectAdditionOfNumbersInAColumn(){
  string? mainString = null;
  for(int j = 1; j < twoDimensionalArrayNumbers.Length; j++){
      int[] test = twoDimensionalArrayNumbers[j-1];
      if(mainString != null){
         twoDimensionalArrayNumbers[j-1] = separatorOfNumberBySubNumbers(mainString);
         mainString = null;
      }
      int g = twoDimensionalArrayNumbers[j-1].Length-1;
      int x = twoDimensionalArrayNumbers[j].Length-1;   
      for(int f = g>x ? f=g : f=x; f>=0; f--){
         subString = null;
         if(x == -1){
         subString = twoDimensionalArrayNumbers[j-1][g].ToString();
         g--;
      }else if(g == -1){
         subString = twoDimensionalArrayNumbers[j][x].ToString();
         x--;
      }else{
         subString = (twoDimensionalArrayNumbers[j-1][g]+twoDimensionalArrayNumbers[j][x]).ToString(); 
         g--;
         x--;
      }
      mainString = subString + mainString;
   }
   twoDimensionalArrayNumbers[j-1] = test;
 }
 return mainString;
}      


Console.WriteLine($"Please enter {СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED} numbers: ");
for(int i = 0; i<СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED; i++){
   stringNumbersArray[i] = Console.ReadLine();
}   
twoDimensionalArrayNumbers = fillArrayNumbers(stringNumbersArray);
for(int y = 0; y<СONSTANT_NUMBER_THAT_DETERMINES_NUMBER_OF_NUMBERS_ENTRED; y++){
   //Shifting the array one element to the left
   arrayMixerOneElementToTheLeft(twoDimensionalArrayNumbers).CopyTo(twoDimensionalArrayNumbers, 0);
   string result = methodOfIncorrectAdditionOfNumbersInAColumn();
   if(Array.IndexOf(resultArray, int.Parse(result))==-1){
      resultArray[y] = int.Parse(result);
      result = null;
      count++;
   }   
}
  outputResult(count);

