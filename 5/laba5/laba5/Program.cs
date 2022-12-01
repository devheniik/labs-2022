// VARIANT 9


namespace Laba
{
    class Program
    {
        static double ReadDouble(string varname, Func<double, bool> unvalidate = null)
        {

            double variable;
            Console.WriteLine($"Input {varname}:");
            while (!double.TryParse(Console.ReadLine(), out variable))
            {
                Console.WriteLine($"Please input correct value for the {varname}: ");
            }

            if (unvalidate != null && unvalidate(variable))
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

        static void Decision(double radius1, double radius2)
        {
            try
            {
                Console.WriteLine($"Square of larger circle: {Math.PI * Math.Pow(radius1, 2)}");
                Console.WriteLine($"Square of lesser circle: {Math.PI * Math.Pow(radius2, 2)}");
                Console.WriteLine($"Square of ring: {Math.PI * Math.Abs(radius1 * radius1 - radius2 * radius2)}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Please enter lesser variables, becouse when multiply happen {e.Message}");
            }

        }

        static void Main(string[] args)
        {
            do
            {
                //Console.Wri
                var inputValue = Console.ReadLine();
                if (!double.TryParse(inputValue, out double radius1)) {
                    //Incorrect value, please input
                    continue
                }
                //Console.Wri
                inputValue = Console.ReadLine();
                if (!double.TryParse(inputValue, out double radius2))
                {
                    //Incorrect value, please input
                    continue
                }
                double radius1 = ReadDouble("radiur larger circle");
                double radius2 = ReadDouble("radiur lesser circle", validatedValue => validatedValue >= radius1);

                Decision(radius1, radius2);

                bool toRepeat = CanRepeat();

            } while (toRepeat);

        }
    }
}

}