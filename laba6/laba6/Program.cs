// VARIANT 9

using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.IO;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

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

        static bool IsEven(int number)
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
        static void VariableSwaiper<T>(ref T e1, ref T e2)
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
                        VariableSwaiper(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }

        static void WriteArray<T>(T[] array, Func<T, int, string> logTransformer)
        {
            var len = array.Length;
            for (var i = 0; i < len; i++)
            {
                Console.WriteLine(logTransformer(array[i], i));
            }
        }

        static void SelectBiggerLine(double[] array, int lineSize)
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

        static int GetRand(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max + 1);
        }
        
        static int[][] GenerateTwoDimensionalArray(int passedXAxisSize = 0, int passedYAxisSize = 0, int minElementValue = 10, int maxElementValue = 99)
        {  
            if (passedXAxisSize < 1 || passedYAxisSize < 1 || passedXAxisSize > passedYAxisSize)
            {
                passedXAxisSize = GetRand(1, 20);
                passedYAxisSize = GetRand(passedXAxisSize, passedXAxisSize + 20); 
            }  

            int[][] responseArray = new int[passedXAxisSize][];

            for(int i = 0; i < passedXAxisSize; i++)
            {
                responseArray[i] = new int[passedYAxisSize];
                for (int j = 0; j < passedYAxisSize; j++)
                { 
                    responseArray[i][j] = GetRand(minElementValue, maxElementValue);
                }
            }

            return responseArray;
        }

 

        static void WriteTwoDimensionalArray<T>(T[][] array)
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

        public static int GetLettersCount(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z]", "").Length;
        }
        public static int ContainsCharacters(string input, char symbol)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == symbol)
                {
                    count++;
                }
            }
            return count;
        }

        public static int IndexOfSymbol(string input, char symbol)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == symbol)
                {
                    return i;
                }
            }
            return -1;
        }

        public static string ConvertPhoneNumber(string input)
        {
            if (input.Length < 10)
            {
                return "Fail!";
            }

            if (input[0] == '+' && ContainsCharacters(input, '+') > 1)
            {

                return "Fail!"; 

            } else if (input[0] != '+' && ContainsCharacters(input, '+') > 0)
            {

                return "Fail!";

            }

            if(ContainsCharacters(input, '(') > 0)
            {
                if(!(IndexOfSymbol(input, '(') < IndexOfSymbol(input, ')'))) return "Fail!";
            }
             

            string digitsOnly = Regex.Replace(input, @"[^\d]", ""); 


            while (digitsOnly.Length > 0 && (digitsOnly[0] == '3' || digitsOnly[0] == '8'))
            {
                digitsOnly = digitsOnly.Substring(1);
            } 

            if (digitsOnly.Length < 10)
            {
                return "Fail!";
            } 

            return "+38 " + digitsOnly.Substring(0, 3) + " " + digitsOnly.Substring(3, 3) + "-" + digitsOnly.Substring(6, 2) + "-" + digitsOnly.Substring(8, 2);
        }

        public static double CalculateExpression(string input)
        { 
            string[] tokens = input.Split(' ');
             
            double result = double.Parse(tokens[0]);
             
            for (int i = 1; i < tokens.Length; i += 2)
            { 
                string op = tokens[i];
                double operand = double.Parse(tokens[i + 1]);
                 
                switch (op)
                {
                    case "+":
                        result += operand;
                        break;
                    case "-":
                        result -= operand;
                        break;
                    case "*":
                        result *= operand;
                        break;
                    case "/":
                        result /= operand;
                        break;
                }
            }

            return result;
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

            WriteArray<double>(arrayBooks, (element, index) => $"Price of {index + 1} book is {element}"); 

            int lineSize = ReadInt("book selected in one line", $"more then 0 lesser then book array size {arrayBooksSize}", validatedVariable => validatedVariable <= 0 && validatedVariable >= arrayBooksSize);

            SelectBiggerLine(arrayBooks, lineSize);

        }

        static void Laba71()
        {
            int[][] array = GenerateTwoDimensionalArray();

            WriteTwoDimensionalArray(array);

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

            int arraySize = ReadInt("X = Y size of array", "more than 9 and even", validatedVariable => validatedVariable < 9 || IsEven(validatedVariable));

            int[][] array = GenerateTwoDimensionalArray(arraySize, arraySize, 10, 99);

            WriteTwoDimensionalArray(array);

            int medianIndex = arraySize / 2;

            for(int i = 1; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if(j < medianIndex)
                    {
                        VariableSwaiper<int>(ref array[i][j], ref array[arraySize - i - 1][arraySize - j - 1]); 
                    }
                }
            }

            WriteTwoDimensionalArray(array);


        } 

        static void Laba81()
        {
            string[] biosList = new string[] 
            {
                "Taras Grigorovich Shevchenko",
                "Larisa Petrovna Kosach-Kvitka",
                "Maria Alexandrovna Vilinskaya",
                "Ivan Semyonovich Nechui-Levitsky",
                "Mikola Grigorovich Khvylyovy",
                "Oles Terentyevich Gonchar"
            };

            foreach (string bio in biosList)
            {
                var splitedBio = bio.Split();
                string name = splitedBio[0];
                string patronymic = splitedBio[1];
                string surname = splitedBio[2];

                string surnameIsLonest = "no";
                int maxSurnameLength = -1;
                foreach (string nestedBio in biosList)
                {
                    var nestedSplitedBio = nestedBio.Split(); 
                    string tempSurname = nestedSplitedBio[2];
                    if (GetLettersCount(tempSurname) > maxSurnameLength) maxSurnameLength = tempSurname.Length;
                }

                if (surname.Length == maxSurnameLength) surnameIsLonest = "yes";




                Console.WriteLine($"-------{bio}------\n");

                Console.WriteLine($"Name: {name}, name length: {GetLettersCount(name)}\n");
                Console.WriteLine($"Patronymic: {patronymic}, patronymic first letter: {patronymic[0]}\n");
                Console.WriteLine($"Surname: {surname}, surname is the longest?: {surnameIsLonest}\n");
                 

            }

        }

        static void Laba82()
        {
            string[] introducedNumbers = new string[]
            {
                "+38 098 456-78-90",
                "38(098)456-78-90",
                "8(098) 456-78-90",
                "0984567890",
                "098456789",
                "+3 098 456+78=90",
                "+38(098 45678-90",
            };

            foreach(string introducedNumber in introducedNumbers)
            {
                Console.WriteLine($"-------------------------------------\n");
                Console.WriteLine($"Tested input: {introducedNumber}");
                Console.WriteLine($"Output: {ConvertPhoneNumber(introducedNumber)} \n");
            }

            Console.WriteLine("---------Live mode----------\n");

            var contine = true;
            while (contine)
            {

                Console.WriteLine("Write your number (0 - to end)");

                string input = Console.ReadLine();

                if(input == "0" || input == null)
                {
                    contine = false;
                    break;
                }

                Console.WriteLine($"\n");
                Console.WriteLine($"-------------------------------------\n");
                Console.WriteLine($"Tested input: {input}");
                Console.WriteLine($"Output: {ConvertPhoneNumber(input)} \n");
                Console.WriteLine($"-------------------------------------\n");



            }

        }

        static void Laba9()
        {
            // Read the expressions from the input file
            string[] expressions = File.ReadAllLines(@"D:\\labs\\laba6\\laba6\\input.txt");

            // Calculate the results of the expressions
            string[] results = new string[expressions.Length];
            for (int i = 0; i < expressions.Length; i++)
            {
                results[i] = CalculateExpression(expressions[i]).ToString();
            }

            // Write the results to the output file
            File.WriteAllLines(@"D:\\labs\\laba6\\laba6\\output.txt", results);
        }

        static void Main(string[] args)
        {
            do
            {
                /*Laba6();
                Laba71();
                Laba72();*/

                Laba9();

                // bool toRepeat = CanRepeat(); *Not in context*

            } while (CanRepeat());

        }
    }
}
 