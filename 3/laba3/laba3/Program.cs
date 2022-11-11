// VARIANT 9
 

namespace Laba
{
    class Program {   
        static bool defaultValidate(double x)
        {
            return false;
        }
        //static double read_double(string varname, Func<bool> validate = (double x) => true)
        static double read_double(string varname, Func<double, bool> validate) 
            { 
                
                double variable; 
                Console.WriteLine($"Input {varname}:"); 
                while (!double.TryParse(Console.ReadLine(), out variable))
                {
                    Console.WriteLine($"Input corrent {varname}:");
                } 

                if (validate(variable))
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
                if (variable != 1 && variable != 2 && variable != 3)
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
                    double x = read_double("x", defaultValidate); 
                    var y = Math.Sqrt(Math.Pow(x, 2) + (5 * x) + 8);  
                    Console.WriteLine($"y: {y}");


                }
                else if (n == 2)
                { 
                    double x = read_double("side of the square", defaultValidate);  
                    Console.WriteLine($"P: {4 * x}, S: {x * x}"); 
                }
                else if (n == 3)
                {
                    double x = read_double("x", defaultValidate);

                    double b = read_double("b", (e) => e >= x);

                    double c = read_double("c", defaultValidate); 

                    var ch = 2 * x - c;
                    var zn = Math.Sqrt(Convert.ToDouble( x - b)); 
                    var abs = x - c;

                    if (abs < 0) {
                        abs = -1 * abs;
                    }
                     

                    Console.WriteLine($"y: {ch / zn - abs}");


                }





                }


/*public double input()
{

}*/ 
        }
    }

 }