// VARIANT 9


namespace Laba
{
    class Program
    {
        static double read_double(string varname, Func<double, bool> validate = null)
        {

            double variable;
            Console.WriteLine($"Input {varname}:");
            while (!double.TryParse(Console.ReadLine(), out variable))
            {
                Console.WriteLine($"Please input correct value for the {varname}: ");
            }

            if (validate != null && validate(variable))
            {
                variable = read_double(varname, validate);
            }

            return variable;
        }
         

        static bool restart()
        {


            Console.WriteLine($"If you want to restart application, write 'yes' [no]");
            string variable = Console.ReadLine();

            if (variable == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void decition(double a, double b)
        {
            double rest = a;
            double contains_plus_one = 1;
            do
            {
                rest = a - contains_plus_one * b;
                contains_plus_one++;

            } while (rest > b);

            Console.WriteLine($"A contain b {contains_plus_one - 1} times");
            Console.WriteLine($"Rest is {rest}");
            Console.WriteLine($"Another way to find rest {a % b}");


            // another way a % b

        }

        static void Main(string[] args)
        {
            try
            {

                do
                {
                    double a = read_double("radius larger circle");
                    double b = read_double("radius lesser circle", e => e >= a);

                    decition(a, b);

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