// VARIANT 9


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
         

        static void Main(string[] args)
        {
            do
            {
                Laba6();

                // bool toRepeat = CanRepeat(); *Not in context*

            } while (CanRepeat());

        }
    }
}
 