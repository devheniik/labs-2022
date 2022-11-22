// VARIANT 9
 

namespace Laba
{
    class Program {   
        static bool defaultValidate(double x)
        {
            return false;
        }

        //static double read_double(string varname, Func<bool> validate = (double x) => true)
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
         
        static int read_task_number(string varname)
            {
                int variable; 
                Console.WriteLine($"Input {varname}:"); 
                while (!int.TryParse(Console.ReadLine(), out variable))
                {
                    Console.WriteLine($"Input corrent {varname}:");
                } 
                if (variable > 0 && variable < 4)
                {
                   variable = read_task_number(varname); 
                } 
                return variable;
            }

        static void Main(string[] args)
        {   
            while(true) {   
                int n = read_task_number("task number"); 

                if (n == 1)
                { 
                    double x = read_double("x"); 
                    var y = Math.Sqrt(Math.Pow(x, 2) + (5 * x) + 8);  
                    Console.WriteLine($"y: {y}");


                }
                else if (n == 2)
                { 
                    double x = read_double("side of the square");  
                    Console.WriteLine($"P: {4 * x}, S: {x * x}"); 
                }
                else if (n == 3)
                {
                    double x = read_double("x");

                    double b = read_double("b", e => {
                        if (e >= x) {
                            Console.WriteLine("");
                            return true;
                        }
                        return false;
                        });

                    double c = read_double("c"); 

                    var ch = 2 * x - c;
                    var zn = Math.Sqrt(x - b); 
                    var abs = x - c;
                    if (abs < 0) {
                        abs = -1 * abs;
                    }
                    Console.WriteLine($"y: {ch / zn - abs}");
                    Console(Math.PI)

                }
            }


/*public double input()
{

}*/ 
        }
    }

 }