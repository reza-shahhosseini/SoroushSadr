using System;
/// <summary>
/// Exercise 1 : Write a program that reads an array from input
/// then calculate sum and average of its values
/// developed by reza_shah.hosseini @ 16 Dec 2021
/// </summary>
namespace SoroushSadrExercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            Print("Number of array elemens : ",newLine:false,beep:false,ConsoleColor.Yellow);
            int result;
            bool succeeded = int.TryParse(Console.ReadLine() , out result);
            if(succeeded){
                var array = new int[result];
                for(int i=0;i<result;i++){
                    Print(message:$"{Ordinal(i+1)} element : ",newLine:false,beep:true,foregroundColor:(i==result-1)?ConsoleColor.Red:ConsoleColor.Blue);
                    array[i] = GetInt32FromUser("Bad input. Please enter an integer and try again.");
                    PrintNewLine();
                }

                PrintArray(array);

                Print($"Sum of array elements is : {CalculateArraySum(array)}",true,true, ConsoleColor.Green);
                Print($"Average of array elements is : {CalculateArrayAverage(array):f2}",true,true,ConsoleColor.Green);

                Console.ReadLine();

            }

        }

        /// <summary>
        /// Pumps a message to output stream
        /// </summary>
        /// <param name="message">the message to be printed</param>
        /// <param name="newLine">whether insert a carriage return at the end of message</param>
        /// <param name="beep">Print the message with a noise</param>
        /// <param name="foregroundColor">specify text color of printed message</param>
        private static void Print(string message,bool newLine = true,bool beep=false, ConsoleColor foregroundColor = ConsoleColor.White){
            if(beep) Console.Beep();
            Console.ForegroundColor = foregroundColor;
            // if(newLine){
            //     Console.WriteLine(message);
            // }else{
            //     Console.Write(message);
            // }
            Console.Write($"{message}{(newLine?'\n':' ')}");
            Console.ResetColor();
        }

        /// <summary>
        /// Get an int value from input stream
        /// </summary>
        /// <param name="message">a message to be printed when user inputs bad data</param>
        /// <returns></returns>
        private static int GetInt32FromUser(string message = ""){
            bool succeeded = false;
            int result = 0;
            while(!succeeded){
                try{
                    result = int.Parse(Console.ReadLine());
                }catch(Exception){
                    Print(message,newLine:true,false,ConsoleColor.Red);
                    Print("New Value: ",false);
                    continue;
                }
                succeeded = true;
            }
            return result;
        }

        /// <summary>
        /// Convert cardinal integer to ordinal string
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>//  
        private static string Ordinal(int number) => number switch{
            1 => "first",
            2 => "second",
            3 => "third",
            _ => $"{number}th"
        };   
    
        /// <summary>
        /// Prints a break line on screen
        /// </summary>
        private static void PrintNewLine(){
            Console.WriteLine("--------------------------------------");
        }
    
        
        /// <summary>
        /// Prints an array of type T on the screen
        /// </summary>
        /// <param name="array">the array to be printed</param>
        /// <param name="separator">the character used for separating between array elements</param>
        /// <typeparam name="T"></typeparam>
        private static void PrintArray<T>(T[] array , string separator=" "){
            foreach(T item in array){
                Print($"{item}{separator}",false);
            }
            Console.WriteLine();
        }
    
        /// <summary>
        /// Calculates the sum of an array 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int CalculateArraySum(int[] array){
            int sum = 0;
            for(int i=0;i<array.Length;i++){
                sum+=array[i];
            }
            return sum;
        }

        /// <summary>
        /// Calculates the average value of array elements
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static decimal CalculateArrayAverage(int[] array){
            return (decimal)CalculateArraySum(array)/array.Length;
        }
    }
}
