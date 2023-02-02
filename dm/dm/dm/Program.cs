internal class Program
{
    static string[,] field = new string[7, 7];
    static void Main(string[] args)
    {
        string rules = "";
        Rules(rules);
        FieldFill(field);
        bool check = CheckForWin(field);
        Console.WriteLine($"\nPress any button to continue");
        Console.ReadKey();
        Console.Clear();
        while (check == false)
        {

            FieldOutput(field);
            PlayerMove();
            BotMoves(field);
            Console.Clear();
            check = CheckForWin(field);
        }


        Console.ReadKey();
    }
    static string ColorText(ConsoleColor fc, string text)
    {
        Console.ForegroundColor = fc;
        Console.Write(text);
        return text;
    }

    static string[,] FieldFill(string[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[i, j] = " ";
            }
        }
        return field;
    }
    static string[,] FieldOutput(string[,] field)
    {

        Console.WriteLine(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 |");
        Console.WriteLine("-+---+---+---+---+---+--—+----");
        int numbers = 0;
        for (int i = 0; i < field.GetLength(0); i++)
        {

            Console.Write($"{numbers}| ");
            for (int j = 0; j < field.GetLength(1); j++)
            {

                if (j != 7)
                {

                    Console.Write(field[i, j] + " | ");
                }
                else
                {
                    Console.Write(field[i, j]);
                }

            }
            if (i != 7)
                Console.WriteLine("\n-+---+---+---+---+---+--—+----");
            numbers++;
        }

        return field;
    }


    static void Rules(string strings)
    {
        string header = "ПРАВИЛА ГРИ <ЧЕТВIРКИ>";
        string space = string.Join("", Enumerable.Repeat(" ", 32));
        string rules = "Четвiрки. Дано поле 7х7. Два противники по черзi виставляють фiшки свого кольору." +
            "\nГрафець 1 - комп'ютер. Фiшки *" +
            "\nГрафець 2 - ви. Фiшки *" +
            "\nВиграє той, хто поставить 4 фiшки в вертикальну, горизонтальну або дiагональну лiнiю.";
        ColorText(ConsoleColor.Red, $"{space + header}\n{rules}\n");

    }
    static bool TryReadNumber(out int number)
    {
        string inputNumber = Console.ReadLine();

        if (!int.TryParse(inputNumber, out number))
        {
            Console.WriteLine("Please, write only numbers.");
            return false;
        }
        if (number > 6 || number < 0)
        {
            Console.WriteLine("Please,write a number from 0 to 6.");
            return false;
        }
        return true;
    }
    static int GetNumber(string message)
    {
        int number;
        do
        {
            Console.WriteLine(message);
        } while (!TryReadNumber(out number));

        return number;
    }
    static string[,] PlayerMove(string info = "")
    {
        Console.WriteLine(info);

        int y = GetNumber("Please select a numeric value for the column:");

        int x = GetNumber("Please select a numeric value for the row:");

        if (y >= 0 && x >= 0 && y <= 6 && x <= 6)
        {
            if (field[x, y] == " ")
            {
                field[x, y] = "*";
            }
            else
            {
                PlayerMove("You can`t move here. Try again.");
                Console.Clear();
            }
        }

        return field;
    }
    static bool CheckForWin(string[,] field)
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                try
                {
                    if (i < 4 || j < 4)
                    {
                        if (field[i, j] == "*" && field[i + 1, j] == "*" && field[i + 2, j] == "*" && field[i + 3, j] == "*")
                        {
                            Console.Clear();
                            Console.WriteLine("YOU WIN");
                            return true;
                        }
                        if (field[i, j] == "*" && field[i, j + 1] == "*" && field[i, j + 2] == "*" && field[i, j + 3] == "*")
                        {
                            Console.Clear();
                            Console.WriteLine("YOU WIN");
                            return true;
                        }
                        if (field[i, j] == "*" && field[i + 1, j + 1] == "*" && field[i + 2, j + 2] == "*" && field[i + 3, j + 3] == "*")
                        {
                            Console.Clear();
                            Console.WriteLine("YOU WIN");
                            return true;
                        }
                        if (field[i, j] == "*" && field[i - 1, j - 1] == "*" && field[i - 2, j - 2] == "*" && field[i - 3, j - 3] == "*")
                        {
                            Console.Clear();
                            Console.WriteLine("YOU WIN");
                            return true;
                        }
                        if (field[i, j] == "*" && field[i + 1, j - 1] == "*" && field[i + 2, j - 2] == "*" && field[i + 3, j - 3] == "*")
                        {
                            Console.Clear();
                            Console.WriteLine("YOU WIN");
                            return true;
                        }
                        //
                        if (field[i, j] == "0" && field[i + 1, j] == "0" && field[i + 2, j] == "0" && field[i + 3, j] == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("COMP WIN");
                            return true;
                        }
                        if (field[i, j] == "0" && field[i, j + 1] == "0" && field[i, j + 2] == "0" && field[i, j + 3] == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("COMP WIN");
                            return true;
                        }
                        if (field[i, j] == "0" && field[i + 1, j + 1] == "0" && field[i + 2, j + 2] == "0" && field[i + 3, j + 3] == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("COMP WIN");
                            return true;
                        }
                        if (field[i, j] == "0" && field[i - 1, j - 1] == "0" && field[i - 2, j - 2] == "0" && field[i - 3, j - 3] == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("COMP WIN");
                            return true;
                        }
                        if (field[i, j] == "0" && field[i + 1, j - 1] == "0" && field[i + 2, j - 2] == "0" && field[i + 3, j - 3] == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("COMP WIN");
                            return true;
                        }
                    }

                }
                catch { }
            }
        }
        return false;
    }
    static string[,] BotMoves(string[,] field)
    {
        Random rnd = new Random();


        while (true)
        {
            int r1 = rnd.Next(0, 7);
            int r2 = rnd.Next(0, 7);
            if (r1 <= 6 || r2 <= 6 || r1 >= 0 || r2 >= 0)
            {
                if (field[r1, r2] == " ")
                {

                    field[r1, r2] = "0";
                    break;

                }
            }
        }
        return field;
    }
}
