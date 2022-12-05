// VARIANT 9

using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Laba
{
    class Program
    {
        static ulong ReadUlong(string varname, string requirements, Func<ulong, bool> unvalidate = null)
        {

            ulong variable;
            Console.WriteLine($"Input {varname}, which follows characteristics such as {requirements}: ");
            while (!ulong.TryParse(Console.ReadLine(), out variable))
            {
                Console.WriteLine($"Please input correct value for the {varname}, which follows characteristics such as {requirements}: ");
            }

            if (unvalidate != null && unvalidate(variable))
            {
                variable = ReadUlong(varname, requirements, unvalidate);
            }

            return variable;
        }

        static int ReadInt(string varname, string requirements, Func<int, bool> unvalidate = null)
        {

            int variable;
            Console.WriteLine($"Input {varname}, which follows characteristics such as {requirements}: ");
            while (!int.TryParse(Console.ReadLine(), out variable))
            {
                Console.WriteLine($"Please input correct value for the {varname}, which follows characteristics such as {requirements}: ");
            }

            if (unvalidate != null && unvalidate(variable))
            {
                variable = ReadInt(varname, requirements, unvalidate);
            }

            return variable;
        }

        static double ReadDouble(string varname, string requirements, Func<double, bool> unvalidate = null)
        {

            double variable;
            Console.WriteLine($"Input {varname}, which follows characteristics such as {requirements}:");
            while (!double.TryParse(Console.ReadLine(), out variable))
            {
                Console.WriteLine($"Please input correct value for the {varname}, which follows characteristics such as {requirements}: ");
            }

            if (unvalidate != null && unvalidate(variable))
            {
                variable = ReadDouble(varname, requirements, unvalidate);
            }

            return variable;
        } 

        static bool CanRepeat()
        {


            Console.WriteLine($"If you want to repeat application, write 'yes' [no]");
            string inputValue = Console.ReadLine();

            return !string.IsNullOrEmpty(inputValue) && string.Equals(inputValue, "yes", StringComparison.OrdinalIgnoreCase);
        }

        static bool isEven(int number)
        {
            if (number < 0)
            {
                throw new Exception("Zero can not be passed as variable to checking for evening");
            } else if (number == 1)
            {
                return false;
            }
            return number % 2 == 0;
        }
        static void variableSwaiper<T>(ref T e1, ref T e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        static double[] BubbleSortDoubleArray(double [] array)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {   
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        variableSwaiper(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }

        static void arrayRepresent<T>(T[] array, Func<T, int, string> logTransformer)
        {
            var len = array.Length;
            for (var i = 0; i < len; i++)
            {
                Console.WriteLine(logTransformer(array[i], i));
            }
        }

        static void selectBiggerLine(double[] array, int lineSize)
        {

            double maxSumm = 0;
            int maxSummIndex = 0;

            var len = array.Length;
            for (var i = 0; i <= len - lineSize; i++)
            {

                double localSumm = 0;

                for (var j = i; j < i + lineSize; j++)
                {
                    localSumm += array[j];
                }

                if (localSumm > maxSumm)
                {
                    maxSumm = localSumm;
                    maxSummIndex = i;
                }


            }

            Console.WriteLine("Bigger not stopped sum");
            Console.WriteLine(maxSumm);
            Console.WriteLine("Index of first elemnt of elements which consists bigger not stopped sum");
            Console.WriteLine(maxSummIndex);
        }

        static int getRand(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max + 1);
        }
        
        static int[][] generateTwoDimensionalArray(int passedXAxisSize = 0, int passedYAxisSize = 0, int minElementValue = 10, int maxElementValue = 99)
        {  
            if (passedXAxisSize < 1 || passedYAxisSize < 1 || passedXAxisSize > passedYAxisSize)
            {
                passedXAxisSize = getRand(1, 20);
                passedYAxisSize = getRand(passedXAxisSize, passedXAxisSize + 20); 
            }  

            int[][] responseArray = new int[passedXAxisSize][];

            for(int i = 0; i < passedXAxisSize; i++)
            {
                responseArray[i] = new int[passedYAxisSize];
                for (int j = 0; j < passedYAxisSize; j++)
                { 
                    responseArray[i][j] = getRand(minElementValue, maxElementValue);
                }
            }

            return responseArray;
        }

 

        static void twoDimensionalArrayRepresent<T>(T[][] array)
        {


            Console.WriteLine("-----------------------------");

            for (int i = 0; i < array.Length; i++)
            {
                string line = "";
                for (int j = 0; j < array[i].Length; j++)
                {
                    string currentLine = 
                    line +=   $"{array[i][j]} ";
                }

                Console.WriteLine(line);
            }

            Console.WriteLine("-----------------------------");

        }

        static void Laba6()
        {
            int arrayBooksSize = ReadInt("Book array size", "more then 0", validatedVariable => validatedVariable <= 0);
            double[] arrayBooks = new double[arrayBooksSize];

            for(int i = 0; i < arrayBooksSize; i++)
            {
                arrayBooks[i] = ReadDouble($"price of {i + 1} book", "more than 0", validatedVariable => validatedVariable <= 0);
            }

            var sortedBooksArray = BubbleSortDoubleArray(arrayBooks);

            arrayRepresent<double>(arrayBooks, (element, index) => $"Price of {index + 1} book is {element}"); 

            int lineSize = ReadInt("book selected in one line", $"more then 0 lesser then book array size {arrayBooksSize}", validatedVariable => validatedVariable <= 0 && validatedVariable >= arrayBooksSize);

            selectBiggerLine(arrayBooks, lineSize);

        }

        static void Laba71()
        {
            int[][] array = generateTwoDimensionalArray();

            twoDimensionalArrayRepresent(array);

            int summOfMaxArrayLine = 0; 
            foreach (int[] row in array)
            {
                int rowSumm = row.Sum();

                if (rowSumm > summOfMaxArrayLine) summOfMaxArrayLine = rowSumm;
            } 


            for (int i = 0; i < array.Length; i++)
            { 
                if (summOfMaxArrayLine == array[i].Sum()) Console.WriteLine($"Index of higher element of array {i}");
            }


        }

        static void Laba72()
        {

            int arraySize = ReadInt("X = Y size of array", "more than 9 and even", validatedVariable => validatedVariable < 9 || isEven(validatedVariable));

            int[][] array = generateTwoDimensionalArray(arraySize, arraySize, 10, 99);

            twoDimensionalArrayRepresent(array);

            int medianIndex = arraySize / 2;

            for(int i = 1; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if(j < medianIndex - 1)
                    {
                        variableSwaiper<int>(ref array[i][j], ref array[arraySize - i - 1][arraySize - j - 1]); 
                    }
                }
            }

            twoDimensionalArrayRepresent(array);


        }



        static void Main(string[] args)
        {
            do
            {
                Laba6();
                Laba71();
                Laba72();

                // bool toRepeat = CanRepeat(); *Not in context*

            } while (CanRepeat());

        }
    }
}
 