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
                Console.WriteLine($"Please pnput correct value for the {varname}: ");
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

        static void decition(double r1, double r2)
        {

            Console.WriteLine($"Square of larger circle: {Math.PI * Math.Pow(r1, 2)}");
            Console.WriteLine($"Square of lesser circle: {Math.PI * Math.Pow(r2, 2)}"); 
            Console.WriteLine($"Square of ring: {Math.PI * Math.Abs(r1 * r1 - r2 * r2)}"); 

        }

        static void Main(string[] args)
        {
            try
            {

                do
                {
                    double r1 = read_double("radiur larger circle");
                    double r2 = read_double("radiur lesser circle", e => e >= r1);

                    decition(r1, r2);

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