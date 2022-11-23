// VARIANT 9


namespace Laba
{
    class Program
    {
        static bool defaultValidate(double x)
        {
            return false;
        }

        static bool restart()
        {
            

            Console.WriteLine($"If you want to restart application, write 'yes' [no]");
            string variable = Console.ReadLine();

            if (variable == "yes") {
                return true;
            } else {
                return false;
            }
        }
        static ulong read_ulong(string varname, Func<ulong, bool> unvalidate = null)
        {

            ulong variable;
            Console.WriteLine($"Input {varname}:");
            while (!ulong.TryParse(Console.ReadLine(), out variable))
            {
                Console.WriteLine($"Please input correct value for the {varname}, this variable must be more that 2 and SIMPLE number (not fractional), at last less than 18446744073709551616 so as ulong");
            }

            if (unvalidate != null && unvalidate(variable))
            {
                variable = read_ulong(varname, unvalidate);
            }

            return variable;
        }
        public static bool IsPrime(ulong number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (ulong)Math.Floor(Math.Sqrt(number));

            for (ulong i = 3; i <= boundary; i += 2) 
                if (number % i == 0) 
                    return false; 
                        

            return true;
        }

        public static double getMersenNumber(ulong p)
        {
            return Math.Pow(2, p) - 1;
        }



        static void Main(string[] args)
        {
            try
            {

                do
                {
                    ulong n = read_ulong("n", arg => arg < 2);
                    ulong p = 1;
                    do
                    {
                        Console.WriteLine(getMersenNumber(p));
                        do
                        {
                            p++;
                        } while (!IsPrime(p));
                    } while (getMersenNumber(p) <= n);
                } while (restart());

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Виключення DivideByZeroException");
            }
            catch (FormatException)
            {
                Console.WriteLine("Виключення FormatException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Виключення OverflowException");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Виключення IndexOutOfRangeException");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Виключення: {e.Message}");
            }
        }
    }

}