// VARIANT 9


namespace Laba
{
    class Program
    {
        static double ReadDouble(string varname, Func<double, bool> validate = null)
        {

            double variable;
            Console.WriteLine($"Input {varname}:");
            while (!double.TryParse(Console.ReadLine(), out variable))
            {
                Console.WriteLine($"Please input correct value for the {varname}: ");
            }

            if (validate != null && validate(variable))
            {
                variable = ReadDouble(varname, validate);
            }

            return variable;
        }
         

        static bool CanRepeat()
        {


            Console.WriteLine($"If you want to repeat application, write 'yes' [no]");
            string inputValue = Console.ReadLine();

            return !string.IsNullOrEmpty(inputValue) && string.Equals(inputValue, "yes", StringComparison.OrdinalIgnoreCase);
        }

        static void Decition(double larger_line, double lesser_line)
        {
            

            Console.WriteLine($"Rest is {larger_line % lesser_line}");


            /*
               double rest = larger_line;
               double contains_plus_one = 1;

            do
            {
                rest = larger_line - contains_plus_one * lesser_line;
                contains_plus_one++;

            } while (rest > lesser_line);

            Console.WriteLine($"A contain b {contains_plus_one - 1} times");
            Console.WriteLine($"Another way to find rest {rest}");*/

        }

        static void Main(string[] args)
        {
            try
            {

                do
                {
                    double larger_line = ReadDouble("larger line size");
                    double lesser_line = ReadDouble("lesser line size", e => e >= larger_line);

                    Decition(larger_line, lesser_line);

                } while (CanRepeat());

            } 
            catch (Exception e)
            { 
                Console.WriteLine($"\tMessage: {e.Message}"); 
            }
        }
    }

}