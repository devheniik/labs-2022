// VARIANT 9
start_of_pr:
Console.WriteLine("Selcet task id:");
start:

int n;
if(!int.TryParse(Console.ReadLine(), out n)) {
    Console.WriteLine("Input corrent task id:");
    goto start;
} 

if (n != 1 && n != 2 && n != 3)
{
    Console.WriteLine("Input corrent task id:");
    goto start;
}

if (n == 1)
{ 

    double x;

    Console.WriteLine("Input x:");
     
    while (!double.TryParse(Console.ReadLine(), out x)){
        Console.WriteLine("Input corrent x:");
    } 
     
    var y = Math.Sqrt(
            Math.Pow(x, 2) + (5 * x) + 8
        ); 

    Console.WriteLine($"y: {y}");


}
else if (n == 2)
{

    double x;

    Console.WriteLine("Input side of the square:");

    while (!double.TryParse(Console.ReadLine(), out x))
    {
        Console.WriteLine("Input corrent side of the square:");
    }

    Console.WriteLine($"P: {4 * x}, S: {x * x}");

}
else if (n == 3)
{
    double x;
    double b;
    double c;

    start_3: 

    Console.WriteLine("Input x:");

    while (!double.TryParse(Console.ReadLine(), out x))
    {
        Console.WriteLine("Input corrent x:");
    }

    Console.WriteLine("Input b:");
start_4:
    while (!double.TryParse(Console.ReadLine(), out b))
    {
        
        Console.WriteLine("Input corrent b:");
    }

    if (b >= x)
    {
        Console.WriteLine("x must be bigger then b, try again:");
        goto start_4;
    }

    Console.WriteLine("Input c:");

    while (!double.TryParse(Console.ReadLine(), out c))
    {
        Console.WriteLine("Input corrent c:");
    }

    var ch = 2 * x - c;
    var zn = Math.Sqrt(Convert.ToDouble( x - b)); 
    var abs = x - c;

    if (abs < 0) {
        abs = -1 * abs;
    }

    if(zn == 0)
    {
        Console.WriteLine("(x - b) must be not zero");
        goto start_3;
    }

    Console.WriteLine($"y: {ch / zn - abs}");


}



goto start_of_pr;